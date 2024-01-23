using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using LSP.Common;
using System.Net.Http.Headers;
using System.IO.Ports;

namespace LASConnector
{
    public partial class MainForm : Form
    {
        // 타이머
        private System.Timers.Timer timer = new System.Timers.Timer();  // 스케쥴 타이머
        private System.Timers.Timer clientConnTimer = new System.Timers.Timer();  // 클라이언트 연결여부 체크 타이머

        // 트레이아이콘에서 종료클릭 여부
        private bool bTrayClose = false;

        // 시리얼통신에 필요한 변수
        public static Dictionary<string, SerialPort> multiSerialPort = new Dictionary<string, SerialPort>();
        public static Dictionary<string, string> comPort_DevCd = new Dictionary<string, string>();
        public static Dictionary<string, string> comPort_parsRuleType = new Dictionary<string, string>();

        public StringBuilder receiveData = new StringBuilder();  // 시리얼통신으로 받은 데이터 저장 버퍼


        #region Init
        public MainForm()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm) init!"));

            InitializeComponent();

            // 응용프로그램DB 파일 문서폴더로 복사.
            CopyDBToDocumentFolder();

            // 로그인폼 셋팅
            ActivateLoginFrm();
        }
        #endregion

        #region method
        // 응용프로그램DB 파일 문서폴더로 복사. 설치하면서 배포된 DB 파일을 도큐먼트 폴더로 복사함. 응용프로그램 폴더는 일반계정에서는 접근이 안됨. 배포시 접근가능 폴더로 배포해도 되나 관리가 어려울듯
        private void CopyDBToDocumentFolder()
        {
            string dbName = @"\LAS.db";
            string documentFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\LASConnector\DB";
            string applicationFolder = Application.StartupPath;

            // 문서폴더에 DB 파일 없으면
            var fi = new FileInfo(documentFolder + dbName);
            if (!fi.Exists)
            {
                // 디렉토리 생성하고
                if (!Directory.Exists(documentFolder))
                    Directory.CreateDirectory(documentFolder);

                // 어플리케이션 폴더에서 도큐먼트 폴더로 DB 복사
                File.Copy(applicationFolder + dbName, documentFolder + dbName, false);
            }

            Global.dbConn = @"Data Source=" + documentFolder + dbName;
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm) Global.dbConn = {0}", Global.dbConn));
        }

        // string to hex
        private string str2hex(string strData)
        {
            string resultHex = string.Empty;
            byte[] arr_byteStr = Encoding.Default.GetBytes(strData);

            foreach (byte byteStr in arr_byteStr)
                resultHex += string.Format("{0:X2}", byteStr);

            return resultHex;
        }
        #endregion

        #region 시리얼통신
        private void initSerialComm()
        {
            // 1. 서버에서 통신설정 가져오기
            // set req params
            var reqParams = new JObject();
            reqParams.Add("comCd", Global.comCd);
            reqParams.Add("plantCd", Global.plantCd);
            reqParams.Add("clientCd", Global.clientSeq);
            reqParams.Add("lang", Global.lang);


            // call api
            string targetUrl = "http://" + Global.svrUrl + "/api/las/selectDeviceList.do";
            JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);

            // 2. 시리얼통신 설정
            string devCd;
            string devWatchFolder;
            string serialPort;
            string ptcType;
            //string parsRuleType;
            int baudRate;
            int dataBit;

            foreach (JObject data in resultJson["data"])
            {
                ptcType = data["ptcType"].ToString();
                devCd = data["devCd"].ToString();
                devWatchFolder = data["devWatchFolder"].ToString();
                //parsRuleType = data["parsRuleType"].ToString();

                // 시리얼통신이고, 감시폴더가 설정되었을 경우
                if (ptcType.Equals("R") && !string.IsNullOrEmpty(devWatchFolder))
                {
                    serialPort = data["serialPort"].ToString();
                    baudRate = Convert.ToInt32(data["baudRate"].ToString());
                    dataBit = Convert.ToInt32(data["dataBit"].ToString());

                    try
                    {
                        // 시리얼통신 연결
                        if (!multiSerialPort.ContainsKey(serialPort))
                        {
                            multiSerialPort.Add(serialPort, new SerialPort(serialPort, baudRate, Parity.None, dataBit, StopBits.One));
                            multiSerialPort[serialPort].DataReceived += Port_DataReceived;
                            multiSerialPort[serialPort].Open();
                            comPort_DevCd.Add(serialPort, devCd);
                            //comPort_parsRuleType.Add(serialPort, parsRuleType);
                        }

                        System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm) initSerialComm(ptcType, devCd, devWatchFolder) = {0}, {1}, {2}", ptcType, comPort_DevCd[serialPort], devWatchFolder));
                        System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm) initSerialComm(port, isopen) = {0}, {1}", serialPort, multiSerialPort[serialPort].IsOpen));

                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm) initSerialComm = {0}", ex.Message));

                        multiSerialPort.Remove(serialPort);
                    }
                }
            }
        }

        // 시리얼통신 이벤트 받기 - 장비감시폴더에 데이터 넣기
        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string portname = ((SerialPort)sender).PortName;
            string msg = ((SerialPort)sender).ReadExisting();
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm) Port_DataReceived(devCd, port, msg) = {0}, {1}, {2}", comPort_DevCd[portname], portname, msg));

            // 저울 버젼
            //// 1. 버퍼에 쌓기
            //receiveData.Append(msg);

            //// 2. 버퍼에 etx 있는지 확인
            //string receiveHex = str2hex(receiveData.ToString());
            //if (receiveHex.Contains("200D0A"))
            //{
            //    // 3. ETX 있으면 파일에 저장하고 버퍼 클리어
            //    System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm) Port_DataReceived(최종데이터) = {0}", receiveData.ToString()));

            //    // 파일저장
            //    string autoTempFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\LASConnector\AutoTemp\" + comPort_DevCd[portname] + @"\";
            //    if (!Directory.Exists(autoTempFolder))
            //        Directory.CreateDirectory(autoTempFolder);

            //    string fileName = comPort_parsRuleType[portname] + "_" + Guid.NewGuid().ToString() + ".txt";
            //    using (StreamWriter outputFile = new StreamWriter(autoTempFolder + fileName))
            //    {
            //        outputFile.WriteLine(receiveData.ToString());
            //    }

            //    // 버퍼 클리어
            //    receiveData.Clear();
            //}
            //else
            //{
            //    System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm) Port_DataReceived(receiveHex) = {0}", receiveHex));
            //}

            // 파일저장
            string autoTempFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\LASConnector\AutoTemp\" + comPort_DevCd[portname] + @"\";
            if (!Directory.Exists(autoTempFolder))
                Directory.CreateDirectory(autoTempFolder);

            string fileName = Guid.NewGuid().ToString() + ".txt";
            using (StreamWriter outputFile = new StreamWriter(autoTempFolder + fileName))
            {
                outputFile.WriteLine(msg);
            }
        }
        #endregion

        #region 감시폴더 감시 처리
        // 감시폴더 트리거 설정
        private void WatchClientFolder()
        {
            // 1. 스케쥴 정보 불러오기
            string sql = @"SELECT 
                      SCHEDULE_SEQ
                    , SCHEDULE_NM
                    , DEV_CD
                    , DEV_NM
                    , DEV_WATCH_FOLDER
                FROM SCHEDULE_INFO
                WHERE USE_YN = 'Y'";
            DataTable dt = SQLiteHelper.SelectDataSet(sql).Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                // 2. 장비별 폴더 생성
                string autoTempFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\LASConnector\AutoTemp\" + dr["DEV_CD"].ToString();
                if (!Directory.Exists(autoTempFolder))
                    Directory.CreateDirectory(autoTempFolder);

                // 3. 감시폴더 트리거 설정
                System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm:WatchClientFolder) start(folder, devcd) = {0}, {1} ", dr["DEV_WATCH_FOLDER"].ToString(), dr["DEV_CD"].ToString()));
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = dr["DEV_WATCH_FOLDER"].ToString();
                watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.Size | NotifyFilters.LastAccess | NotifyFilters.CreationTime | NotifyFilters.LastWrite;
                watcher.Filter = "*.*";
                watcher.IncludeSubdirectories = true;

                var handler = new FileSystemEventHandler((s, e) => WatchFileChanged(s, e, dr["DEV_CD"].ToString(), dr["DEV_WATCH_FOLDER"].ToString()));
                watcher.Created += handler;
                watcher.Changed += handler;

                watcher.EnableRaisingEvents = true;
            }
        }

        // 감시폴더내 파일 생성시 이벤트 (임시폴더로 파일 이동)
        private void WatchFileChanged(object source, FileSystemEventArgs e, string devCd, string clientWatchFolder)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm:WatchFileChanged) e.FullPath, e.ChangeType = {0}, {1}", e.FullPath, e.ChangeType));

            try
            {
                var fi = new FileInfo(e.FullPath);
                if (fi.Exists && fi.Length > 0)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm:WatchFileChanged) fi.FullName, fi.Exist, fi.Length = {0}, {1}, {2}", fi.FullName, fi.Exists, fi.Length));

                    // 서브폴더 포함 카피 경로 셋팅
                    string subFolderPath = fi.DirectoryName.Replace(clientWatchFolder, "");

                    string autoTempFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\LASConnector\AutoTemp\" + devCd + @"\" + subFolderPath + @"\";
                    if (!Directory.Exists(autoTempFolder))
                        Directory.CreateDirectory(autoTempFolder);

                    fi.CopyTo(autoTempFolder + fi.Name, true);
                    File.SetAttributes(autoTempFolder + fi.Name, FileAttributes.Normal);

                    System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm:WatchFileChanged) CopyTo Dest = {0}", autoTempFolder));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm:WatchFileChanged) ex = {0}", ex.ToString()));
            }
        }
        #endregion

        #region 폼 활성화 method
        // 메인폼 활성화/비활성화
        private void ActivateMainFrm(bool activate)
        {
            this.Visible = activate;
            this.ShowIcon = activate;
            this.Activate();
        }

        // activate 로그인폼 
        public void ActivateLoginFrm()
        {
            Login loginFrm = new Login();
            loginFrm.FrmSendEvent += new Login.FrmSendDataHandler(ProcLoginFrmEvent);
            loginFrm.TopLevel = false;
            loginFrm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            loginFrm.Dock = DockStyle.Fill;

            panMain.Controls.Clear();
            panMain.Controls.Add(loginFrm);
            loginFrm.Parent = this.panMain;

            loginFrm.Show();
        }

        // activate 서브폼
        public void ActivateSubFrm(string activateFrm)
        {
            SubForm subFrm = new SubForm(activateFrm);
            subFrm.FrmSendEvent += new SubForm.FrmSendDataHandler(ProcSubFrmEvent);
            subFrm.TopLevel = false;
            subFrm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            subFrm.Dock = DockStyle.Fill;

            panMain.Controls.Clear();
            panMain.Controls.Add(subFrm);
            subFrm.Parent = this.panMain;

            subFrm.Show();

            this.MinimizeBox = true;
            this.MaximizeBox = true;
        }
        #endregion

        #region 트레이아이콘 이벤트
        // 화면 축소시
        private void MainForm_Resize(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm) MainForm_Resize"));

            if (this.WindowState == FormWindowState.Minimized)
            {
                // 트레이아이콘 변경하면서 작업표시줄에서 없애면 winproc 함수를 타지 않아서 주석처리
                //this.Visible = false;
                //this.ShowIcon = false;

                //trayMain.Visible = true;
                //trayMain.ShowBalloonTip(10);
            }

            //EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);
        }

        // 폼종료시
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm) MainForm_FormClosing"));

            if (this.WindowState == FormWindowState.Minimized || bTrayClose)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;

                //trayMain.ShowBalloonTip(10);
            }
        }

        // 트레이아이콘 더블 클릭시
        private void trayMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm) trayMain_MouseDoubleClick"));

            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            // 메인폼 활성화            
            ActivateMainFrm(true);
        }

        // 데이터이력 툴팁메뉴 선택시
        private void tsmiDataHistory_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            // 메인폼 활성화            
            ActivateMainFrm(true);

            // activate 서브폼
            ActivateSubFrm("dataHisotryFrm");
        }

        // 장비현황관리 툴팁메뉴 클릭시
        private void tsmiDeviceMng_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            // 메인폼 활성화            
            ActivateMainFrm(true);

            // activate 서브폼
            ActivateSubFrm("deviceMngFrm");
        }

        // 종료 선택시
        private void tsmiMainClose_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm) tsmiMainClose_Click"));
            this.WindowState = FormWindowState.Minimized;

            // 로그인 했을때만 로그아웃
            if (Global.loginYn.Equals("Y"))
            {
                // set req params
                var reqParams = new JObject();
                reqParams.Add("userId", Global.userPk);
                reqParams.Add("plantCd", Global.plantCd);
                reqParams.Add("comCd", Global.comCd);

                // call
                string targetUrl = "http://" + Global.svrUrl + "/api/config/logout.do";
                JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);
            }
            this.Close();
        }
        #endregion

        #region 로그인폼, 서브폼에서 호출하는 이벤트
        // 서브폼에서 호출하는 이벤트
        public void ProcSubFrmEvent(Object obj)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm:ProcSubFrmEvent) 서브폼에서 호출"));
        }

        // 로그인폼에서 호출하는 이벤트(로그인 성공 후 이벤트 처리)
        public void ProcLoginFrmEvent(Object obj)
        {
            // 1. Global 정보 셋팅
            JObject loginInfo = (JObject)obj;
            Global.loginYn = "Y";
            Global.userId = loginInfo["userId"].ToString();
            Global.userPk = loginInfo["userPk"].ToString();
            Global.userNm = loginInfo["userNm"].ToString();
            Global.deptNm = loginInfo["deptNm"].ToString();
            Global.teamNm = loginInfo["teamNm"].ToString();
            Global.authToken = loginInfo["authToken"].ToString();

            // 컴퓨터 아이피
            IPAddress[] host = Dns.GetHostAddresses(Dns.GetHostName());
            Global.clientIP = host[1].ToString();

            // 클라이언트정보 설정
            string sql = "SELECT COM_CD, FTP_IP, FTP_ID, FTP_PWD, CLIENT_SEQ, CLIENT_ID FROM BASIC_INFO";
            DataTable dt = SQLiteHelper.SelectDataSet(sql).Tables[0];
            Global.comCd = dt.Rows[0]["COM_CD"].ToString();
            Global.clientSeq = dt.Rows[0]["CLIENT_SEQ"].ToString();

            // 클라이언트 연결여부
            string clientUrl = "http://" + Global.svrUrl + "/api/las/checkClientConn.do";
            var reqParams = new JObject();
            reqParams.Add("comCd", Global.comCd);
            reqParams.Add("plantCd", Global.plantCd);
            reqParams.Add("clientPk", Global.clientSeq);
            JObject clientResult = RestApiRequest.CallAsyncWithResult(reqParams, clientUrl);
            if (!clientResult["result"].ToString().Equals("success"))
                Global.clientSeq = "0";

            #region Audit - insert/update
            string auditSql = "SELECT SVR_SEQ, SVR_NM, SVR_IP, DEFAULT_YN, REG_DT, REG_ID, MOD_DT, MOD_ID, SVR_PK FROM SVR_INFO ORDER BY SVR_SEQ DESC";
            DataTable auditDt = SQLiteHelper.SelectDataSet(auditSql).Tables[0];
            string auditUrl = "http://" + Global.svrUrl + "/api/las/insertSvrInfo.do";

            foreach (DataRow dr in auditDt.Rows)
            {
                var auditParams = new JObject();
                auditParams.Add("svrSeq", dr["SVR_SEQ"].ToString());
                auditParams.Add("svrNm", dr["SVR_NM"].ToString());
                auditParams.Add("svrIp", dr["SVR_IP"].ToString());
                auditParams.Add("defaultYn", dr["DEFAULT_YN"].ToString());
                auditParams.Add("regDt", dr["REG_DT"].ToString());
                auditParams.Add("regId", Global.userPk);

                if (!String.IsNullOrEmpty(dr["MOD_DT"].ToString()))
                {
                    auditParams.Add("modDt", dr["MOD_DT"].ToString());
                    auditParams.Add("modId", Global.userPk);
                }

                string svrPk = dr["SVR_PK"].ToString();
                auditParams.Add("svrPk", string.IsNullOrEmpty(svrPk) ? "0" : svrPk);
                JObject auditResult = RestApiRequest.CallSync(auditParams, auditUrl);

                string sql2 = string.Format("UPDATE SVR_INFO SET SVR_PK = '{0}' WHERE SVR_SEQ = '{1}'", auditResult["svrPk"], auditResult["svrSeq"]);
                SQLiteHelper.SaveData(sql2);
            }
            #endregion

            // 2. 트레이아이콘 활성화
            tsmiDataHistory.Enabled = true;
            tsmiDeviceMng.Enabled = true;

            // 3. activate 서브폼
            ActivateSubFrm("dataHisotryFrm");

            // 4. 클라이언트연결이 유효하면 - 폴더 감시 및 타이머 시작 / 시리얼 통신 초기화
            if (!Global.clientSeq.Equals("0"))
            {
                WatchClientFolder();

                SetTimer();

                SetClientConnTimer();

                // 시리얼통신 초기화
                initSerialComm();
            }

            // 5. 화면 크기 조정 가능하도록 변경
            this.AutoSizeMode = AutoSizeMode.GrowOnly;


            Control cs = ((SubForm)panMain.Controls[0]).Controls[0];
        }
        #endregion

        #region 타이머
        // 타이머 시작
        private void SetTimer()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:SetTimer) start!"));

            timer.Interval = 10000; // 10초
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }

        // 임시감시폴더 확인해서 파일전송
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Enabled = false;
            System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) 1. 저장된 스케쥴로딩 = {0}", DateTime.Now.ToString()));

            // 0. 클라이언트 연결여부 체크 - 파일업로드시 오류 나므로 굳이 호출 하지 않는 편이 나을듯
            //string clientUrl = "http://" + Global.svrUrl + "/api/las/checkClientConn.do";
            //var clientParams = new JObject();
            //clientParams.Add("comCd", Global.comCd);
            //clientParams.Add("plantCd", Global.plantCd);
            //clientParams.Add("clientPk", Global.clientSeq);
            //JObject clientResult = RestApiRequest.CallAsyncWithResult(clientParams, clientUrl);
            //if (!clientResult["result"].ToString().Equals("success"))
            //{
            //    Global.clientSeq = "0";
            //    timer.Enabled = false;
            //    return;
            //}

            // 1. 저장된 스케쥴로딩
            string sql = @"
                SELECT 
                    SCHEDULE_SEQ, DEV_CD, DEV_NM, FILE_TYPE, DEV_WATCH_FOLDER, REALTIME_YN, UPLOAD_TIME, UPLOAD_FROM_DT, UPLOAD_FROM_TIME, UPLOAD_TO_DT, UPLOAD_TO_TIME, USE_YN
                FROM SCHEDULE_INFO 
                WHERE USE_YN = 'Y'";
            DataTable dt = SQLiteHelper.SelectDataSet(sql).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                // 2. 저장된 업로드기간, 실시간여부 가져오기
                System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) 2. 저장된 스케쥴정보 가져오기 = {0}, {1}, {2}, {3}, {4}", dr["DEV_CD"].ToString(), dr["REALTIME_YN"].ToString(), dr["UPLOAD_TIME"].ToString(), dr["UPLOAD_FROM_DT"].ToString(), dr["UPLOAD_FROM_TIME"].ToString()));

                // 업로드 기간
                DateTime dtNow = DateTime.Now;
                DateTime dtUploadFrom = DateTime.Parse(dr["UPLOAD_FROM_DT"].ToString() + " " + dr["UPLOAD_FROM_TIME"].ToString());
                DateTime dtUploadTo = DateTime.Parse(dr["UPLOAD_TO_DT"].ToString() + " " + dr["UPLOAD_TO_TIME"].ToString());
                System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) dtNow = {0}", dtNow.ToString()));
                System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) dtUploadFrom = {0}", dtUploadFrom.ToString()));
                System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) dtUploadTo = {0}", dtUploadTo.ToString()));

                // 1일1회 업로드일 경우 업로드 시간
                TimeSpan tsNow = TimeSpan.Parse(dtNow.ToString("HH:mm:ss"));
                TimeSpan tsUploadTime = TimeSpan.Parse(dr["UPLOAD_TIME"].ToString());
                TimeSpan tsGap = tsNow - tsUploadTime;
                System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) tsNow, tsUploadTime, tsGap= {0}, {1}, {2}", tsNow.ToString(), tsUploadTime.ToString(), tsGap.TotalSeconds));

                // 3. 업로드 기간에 해당될 경우
                if (dtUploadFrom <= dtNow && dtNow <= dtUploadTo)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) 3. 업로드 기간에 해당될 경우"));

                    // 4 실시간 이거나, 1일1회 업로드시간에 해당될 경우
                    //if (dr["REALTIME_YN"].ToString().Equals("Y") || Math.Abs(tsGap.TotalSeconds) < 60)
                    if (dr["REALTIME_YN"].ToString().Equals("Y") || (0 < tsGap.TotalSeconds && tsGap.TotalSeconds < 30))
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) 4 실시간 이거나, 1일1회 업로드시간에 해당될 경우"));

                        // 5. 임시감시폴더에 데이터 있는지 체크
                        string autoTempFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\LASConnector\AutoTemp\" + dr["DEV_CD"].ToString();
                        DirectoryInfo di = new DirectoryInfo(autoTempFolder);
                        int iFileCnt = di.GetFiles().Length;
                        System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) iFileCnt = "), iFileCnt);

                        foreach (FileInfo fi in di.GetFiles("*", SearchOption.AllDirectories))
                        {
                            // 6. 파싱룰 타입이 같을 경우만 진행
                            //if ((dr["FILE_TYPE"].ToString().Equals("P") && fi.Extension.ToLower().Equals(".pdf")) ||
                            //    (dr["FILE_TYPE"].ToString().Equals("T") && !fi.Extension.ToLower().Equals(".pdf")))
                            //{
                                System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) 5. 감시폴더에 데이터 있는지 체크 = {0}, {1}, {2}", fi.Name, fi.Length, fi.CreationTime));
                                try
                                {
                                    // 7. FTP 전송
                                    System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) 7. 파일 전송"));
                                    JObject ftpResult = FTPApi.Upload("http://" + Global.svrUrl + "/api/las/insertFile.do", "devCd=" + dr["DEV_CD"].ToString(), fi.FullName);

                                    // 8. 서버에 파일정보 전송하기
                                    System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) 8. 서버에 전송이력 전송하기"));
                                    // set req params
                                    var reqParams = new JObject();
                                    reqParams.Add("fileInfPk", ftpResult["fileInfPk"].ToString());
                                    reqParams.Add("devCd", dr["DEV_CD"].ToString());
                                    reqParams.Add("clientSeq", Global.clientSeq);
                                    reqParams.Add("comCd", Global.comCd);
                                    reqParams.Add("plantCd", Global.plantCd);
                                    reqParams.Add("fileDiv", fi.Extension.Substring(1));
                                    reqParams.Add("fileRegDt", fi.CreationTime.ToShortDateString().Replace("-", ""));
                                    reqParams.Add("fileSize", fi.Length);
                                    reqParams.Add("orgFileNm", fi.Name);
                                    reqParams.Add("orgPath", dr["DEV_WATCH_FOLDER"].ToString().Substring(3) + fi.DirectoryName.Replace(autoTempFolder, ""));
                                    reqParams.Add("transDt", dtNow.ToString("yyyy-MM-dd HH:mm:ss"));
                                    reqParams.Add("regDt", dtNow.ToString("yyyy-MM-dd HH:mm:ss"));
                                    reqParams.Add("regId", Global.userPk);
                                    reqParams.Add("regIp", Global.clientIP);
                                    reqParams.Add("modDt", dtNow.ToString("yyyy-MM-dd HH:mm:ss"));
                                    reqParams.Add("modId", Global.userPk);
                                    reqParams.Add("modIp", Global.clientIP);
                                    // call api
                                    string targetUrl = "http://" + Global.svrUrl + "/api/las/insertFileInfoLAS.do";
                                    JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);

                                    // 9. 전송된 파일은 삭제
                                    fi.Delete();

                                    // 10. 로컬 DB에 성공 로그 남기기
                                    System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) 10. 로컬 DB에 성공 로그 남기기"));
                                    sql = string.Format(@"INSERT INTO TRANS_HISTORY 
                                        (AUTO_YN, FILE_NM, FILE_SIZE, REG_ID, REG_DT, TRANS_YN, TRY_CNT, SVR_TRANS_DT, DEV_CD, DEV_NM, SEND_LOC)
                                        VALUES 
                                        ('Y', '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')"
                                            , fi.Name
                                            , fi.Length
                                            , Global.userId
                                            , fi.CreationTime
                                            , "Success"
                                            , 1
                                            , dtNow.ToString("yyyy-MM-dd HH:mm:ss")
                                            , dr["DEV_CD"].ToString()
                                            , dr["DEV_NM"].ToString()
                                            , dr["DEV_WATCH_FOLDER"].ToString() + fi.DirectoryName.Replace(autoTempFolder, "")
                                            );
                                    SQLiteHelper.SaveData(sql);
                                }
                                catch (Exception ex)
                                {
                                    // 10. 로컬 DB에 실패 로그 남기기
                                    System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) 10. 로컬 DB에 실패 로그 남기기"));
                                    sql = string.Format(@"INSERT INTO TRANS_HISTORY 
                                        (AUTO_YN, FILE_NM, FILE_SIZE, REG_ID, REG_DT, TRANS_YN, TRY_CNT, SVR_TRANS_DT, FAIL_REASON, DEV_CD, DEV_NM, SEND_LOC)
                                        VALUES 
                                        ('Y', '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}', '{9}', '{10}')"
                                            , fi.Name
                                            , fi.Length
                                            , Global.userId
                                            , fi.CreationTime
                                            , "Fail"
                                            , 1
                                            , dtNow.ToString()
                                            , ex.Message
                                            , dr["DEV_CD"].ToString()
                                            , dr["DEV_NM"].ToString()
                                            , dr["DEV_WATCH_FOLDER"].ToString() + fi.DirectoryName.Replace(autoTempFolder, "")
                                            );
                                    SQLiteHelper.SaveData(sql);

                                    // 11. 실패된 파일 실패폴더로 옮기기
                                    System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm:timer) 11. 실패된 파일 실패폴더로 옮기기"));

                                    string failTempFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\LASConnector\FailTemp\";
                                    if (!Directory.Exists(failTempFolder))
                                        Directory.CreateDirectory(failTempFolder);

                                    fi.MoveTo(failTempFolder + fi.Name);
                                    System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm:timer) dest = {0}", failTempFolder));
                                }
                            //}
                        }

                        // parser 호출 - 파일이 있을 경우만 호출
                        //if (iFileCnt > 0)
                        //{
                            var reqParseParams = new JObject();
                            string targetParseUrl = "http://" + Global.svrUrl + "/api/las/ruleParse.do";
                            RestApiRequest.CallAsync(reqParseParams, targetParseUrl);
                        //}
                    }
                }
            }

            System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) end = {0}", DateTime.Now.ToLongTimeString()));
            timer.Enabled = true;
        }


        // 클라이언트 연결여부 타이머
        private void SetClientConnTimer()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:SetClientConnTimer) start!"));

            clientConnTimer.Interval = 60000; // 60초
            clientConnTimer.Elapsed += new ElapsedEventHandler(clientConnTimer_Elapsed);
            clientConnTimer.Start();
        }

        private void clientConnTimer_Elapsed(object sender, ElapsedEventArgs e)
        {

            clientConnTimer.Enabled = false;
            System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:clientConnTimer_Elapsed) "));

            // 0. 클라이언트 연결여부 체크 - 파일업로드시 오류 나므로 굳이 호출 하지 않는 편이 나을듯
            string clientUrl = "http://" + Global.svrUrl + "/api/las/checkClientConn.do";
            var clientParams = new JObject();
            clientParams.Add("comCd", Global.comCd);
            clientParams.Add("plantCd", Global.plantCd);
            clientParams.Add("clientPk", Global.clientSeq);
            JObject clientResult = RestApiRequest.CallAsyncWithResult(clientParams, clientUrl);
            if (!clientResult["result"].ToString().Equals("success"))
            {
                Global.clientSeq = "0";
                timer.Enabled = false;
                clientConnTimer.Enabled = false;

                ((SubForm)panMain.Controls[0]).Controls[1].Controls[2].Enabled = false;
                ((SubForm)panMain.Controls[0]).Controls[1].Controls[3].Enabled = false;

                return;
            }

            clientConnTimer.Enabled = true;
        }
        #endregion
    }
}
