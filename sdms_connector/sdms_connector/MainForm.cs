using LSP.Common;
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

namespace sdms_connector
{
    public partial class MainForm : Form
    {
        // 타이머
        private System.Timers.Timer timer = new System.Timers.Timer();

        // 감시폴더
        private FileSystemWatcher watcher = null;

        #region clawPDF 호출 처리
        const int WM_PDF = 0x4A;

        // 전송메시지
        public struct PDFDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }

        // WndProc
        protected override void WndProc(ref Message m)
        {
            //System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm) WndProc m = ", m.ToString()));

            switch (m.Msg)
            {
                case WM_PDF:
                    PDFDATASTRUCT pds = (PDFDATASTRUCT)m.GetLParam(typeof(PDFDATASTRUCT));
                    System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm) WndProc pds.lpData = {0}[END]", pds.lpData));

                    // 트레이아이콘 상태면
                    if (this.WindowState == FormWindowState.Minimized)
                        this.WindowState = FormWindowState.Normal;

                    // 메인폼 활성화            
                    ActivateMainFrm(true);

                    // 미로그인일때 
                    if (!Global.loginYn.Equals("Y"))
                    {
                        MessageBox.Show(Global.GetMultiLang("E-MSG-LOGIN_CHECK", "SDMS Connector 로그인이 되어야 파일이 정상적으로 처리됩니다."), "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                    // 자동전송 이면, 아무런 이벤트도 없음.
                    if (Global.folderAutoYn.Equals("Y"))
                    {
                        MessageBox.Show(Global.GetMultiLang("E-MSG-CHECK-SDMS_MODE", "현재 SDMS Connector는 자동모드 이므로 PDF로 변환하신 파일이 처리되지 않습니다."), "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                    // 클라이언트 연결여부 체크
                    string clientUrl = "http://" + Global.svrUrl + "/api/sdms/checkClientConn.do";
                    var clientParams = new JObject();
                    clientParams.Add("comCd", Global.comCd);
                    clientParams.Add("plantCd", Global.plantCd);
                    clientParams.Add("clientPk", Global.clientSeq);
                    JObject clientResult = RestApiRequest.CallAsyncWithResult(clientParams, clientUrl);
                    if (!clientResult["result"].ToString().Equals("success"))
                    {
                        MessageBox.Show(Global.GetMultiLang("E-MSG-CLIENT_DISCONN.", "클라이언트 등록이 해제되었습니다.\n관리자에게 문의하시기 바랍니다."), "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Global.clientSeq = "0";
                        break;
                    }


                    // activate PDF폼
                    ActivatePdfFrm(pds.lpData);

                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion

        #region Init
        public MainForm()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm) init!"));

            InitializeComponent();

            // 자동임시폴더 생성
            string autoTempFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\SDMSConnector\AutoTemp\";
            if (!Directory.Exists(autoTempFolder))
                Directory.CreateDirectory(autoTempFolder);


            // 응용프로그램DB 파일 문서폴더로 복사.
            CopyDBToDocumentFolder();

            // 로그인폼 셋팅
            ActivateLoginFrm();

            #region pdf 수동 테스트
            //var resultJson = new JObject();
            //resultJson.Add("userId", "4");
            //resultJson.Add("userNm", "홍길동");
            //resultJson.Add("deptNm", "생산본부");
            //resultJson.Add("teamNm", "QC팀");
            //Global.plantCd = "0000";
            //Global.comCd = "0000";
            //Global.svrUrl = "10.1.202.23:8080";
            //ProcLoginFrmEvent(resultJson);
            ////ActivatePdfFrm(@"C:\Users\inglo\Documents\카카오톡 받은 파일\SDMS 인쇄 테스트.txt|C:\Users\inglo\Documents\SDMSConnector\ManualTemp\SDMS 인쇄 테스트.pdf");
            //ActivatePdfFrm(@"SDMS 인쇄 테스트.txt|C:\Users\inglo\Documents\SDMSConnector\ManualTemp\SDMS 인쇄 테스트.pdf");
            #endregion
        }
        #endregion

        #region method
        // 응용프로그램DB 파일 문서폴더로 복사.
        // 설치하면서 배포된 DB 파일을 도큐먼트 폴더로 복사함. 응용프로그램 폴더는 일반계정에서는 접근이 안됨. 배포시 접근가능 폴더로 배포해도 되나 관리가 어려울듯
        private void CopyDBToDocumentFolder()
        {
            string dbName = @"\SDMS.db";
            string documentFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\SDMSConnector\DB";
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
        #endregion

        #region 감시폴더 감시 처리
        // 감시폴더 트리거 설정
        private void WatchClientFolder()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm:WatchClientFolder) start"));

            // 초기화 해주지 않으면 여러번 지정할 경우 이벤트가 지정횟수 만큼 발생한다.
            if (watcher != null)
            {
                watcher.Dispose();
            }

            watcher = new FileSystemWatcher();

            watcher.Path = Global.clientWatchFolder;
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.Size | NotifyFilters.LastAccess | NotifyFilters.CreationTime | NotifyFilters.LastWrite;
            watcher.Filter = "*.*";
            watcher.IncludeSubdirectories = true;

            watcher.Created += new FileSystemEventHandler(WatchFileChanged);
            watcher.Changed += new FileSystemEventHandler(WatchFileChanged);

            watcher.EnableRaisingEvents = true;

            System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm:WatchClientFolder) watcher.Path = {0}", watcher.Path));
        }

        // 감시폴더내 파일 생성시 이벤트 (임시폴더로 파일 이동)
        private void WatchFileChanged(object source, FileSystemEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm:WatchFileChanged) e.FullPath, e.ChangeType = {0}, {1}", e.FullPath, e.ChangeType));

            try
            {
                var fi = new FileInfo(e.FullPath);
                if (fi.Exists && fi.Length > 0)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm:WatchFileChanged) fi.FullName, fi.Exist, fi.Length = {0}, {1}, {2}", fi.FullName, fi.Exists, fi.Length));

                    // 서브폴더 포함 카피 경로 셋팅
                    string subFolderPath = fi.DirectoryName.Replace(Global.clientWatchFolder, "");

                    string autoTempFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\SDMSConnector\AutoTemp" + subFolderPath + @"\";
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
            //EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);
        }

        // activate PDF폼
        public void ActivatePdfFrm(string fileFullPath)
        {
            PdfForm pdfFrm = new PdfForm(fileFullPath);
            pdfFrm.FrmSendEvent += new PdfForm.FrmSendDataHandler(ProcPdfFrmEvent);
            pdfFrm.TopLevel = false;
            pdfFrm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            pdfFrm.Dock = DockStyle.Fill;

            panMain.Controls.Clear();
            panMain.Controls.Add(pdfFrm);
            pdfFrm.Parent = this.panMain;

            pdfFrm.Show();

            this.MinimizeBox = false;
            //EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);
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
                //this.ShowInTaskbar = false;

                //trayMain.ShowBalloonTip(10);
            }

            //EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);
        }

        // 폼종료시
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm) MainForm_FormClosing"));

            if (this.WindowState == FormWindowState.Minimized)
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

            //this.ShowInTaskbar = true;

            // 메인폼 활성화            
            ActivateMainFrm(true);
        }

        // 데이터이력 메뉴 선택시
        private void tsmiDataHistory_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            //this.ShowInTaskbar = true;

            // 메인폼 활성화            
            ActivateMainFrm(true);

            // activate 서브폼
            ActivateSubFrm("dataHisotryFrm");
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

        #region 로그인폼, PDF폼, 서브폼에서 호출하는 이벤트
        // 서브폼에서 호출하는 이벤트
        public void ProcSubFrmEvent(Object obj)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm:ProcSubFrmEvent) 서브폼에서 호출 obj = {0}", obj.ToString()));

            // 감시모드가 자동이면 - 폴더 감시 및 타이머 시작
            if (obj.Equals("auto"))
            {
                WatchClientFolder();

                SetTimer();
            }
            // 감시모드가 수동이면 - 폴더 감시 및 타이머 해제
            else
            {
                if (watcher != null)
                {
                    watcher.EnableRaisingEvents = false;
                    timer.Enabled = false;
                }
            }
        }

        // PDF폼에서 호출하는 이벤트(저장, 취소 완료후 이벤트 처리)
        public void ProcPdfFrmEvent(Object obj)
        {
            // activate 서브폼
            ActivateSubFrm("dataHisotryFrm");

            // 화면축소
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Minimized;
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
            string sql = "SELECT COM_CD, FTP_IP, FTP_ID, FTP_PWD, CLIENT_SEQ, CLIENT_ID, CLIENT_WATCH_FOLDER, FOLDER_AUTO_YN FROM BASIC_INFO";
            DataTable dt = SQLiteHelper.SelectDataSet(sql).Tables[0];
            Global.clientSeq = dt.Rows[0]["CLIENT_SEQ"].ToString();
            Global.clientID = dt.Rows[0]["CLIENT_ID"].ToString();
            Global.clientWatchFolder = dt.Rows[0]["CLIENT_WATCH_FOLDER"].ToString();
            Global.folderAutoYn = dt.Rows[0]["FOLDER_AUTO_YN"].ToString();
            //System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm:ProcLoginFrmEvent) clientID, clientWatctdsfdshFolder, folderAutoYn = {0}, {1}, {2}", Global.clientID, Global.clientWatchFolder, Global.folderAutoYn));

            // 클라이언트 연결여부
            string clientUrl = "http://" + Global.svrUrl + "/api/sdms/checkClientConn.do";
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
            string auditUrl = "http://" + Global.svrUrl + "/api/sdms/insertSvrInfo.do";

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

                if (!String.IsNullOrEmpty(dr["SVR_PK"].ToString()))
                    auditParams.Add("svrPk", dr["SVR_PK"].ToString());
                else
                    auditParams.Add("svrPk", 0);

                JObject auditResult = RestApiRequest.CallSync(auditParams, auditUrl);

                string sql2 = string.Format("UPDATE SVR_INFO SET SVR_PK = '{0}' WHERE SVR_SEQ = '{1}'", auditResult["svrPk"], auditResult["svrSeq"]);
                SQLiteHelper.SaveData(sql2);
            }
            #endregion

            // 2. 트레이아이콘 활성화
            tsmiDataHistory.Enabled = true;

            // 3. activate 서브폼
            ActivateSubFrm("dataHisotryFrm");

            // 4. 감시모드가 자동이고, 클라이언트연결이 유효하면 - 폴더 감시 및 타이머 시작
            if (Global.folderAutoYn.Equals("Y") && !Global.clientSeq.Equals("0"))
            {
                WatchClientFolder();

                SetTimer();
            }

            // 5. 화면 크기 조정 가능하도록 변경
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
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
            //string clientUrl = "http://" + Global.svrUrl + "/api/sdms/checkClientConn.do";
            //var clientParams = new JObject();
            //clientParams.Add("comCd", Global.comCd);
            //clientParams.Add("plantCd", Global.plantCd);
            //clientParams.Add("clientPk", Global.clientSeq);
            //JObject clientResult = RestApiRequest.CallAsyncWithResult(clientParams, clientUrl);
            //if (!clientResult["result"].ToString().Equals("success"))
            //{
            //    Global.clientSeq = "0";
            //    watcher.EnableRaisingEvents = false;
            //    timer.Enabled = false;
            //    return;
            //}

            string autoTempFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\SDMSConnector\AutoTemp";

            // 1. 저장된 스케쥴로딩
            string sql = @"SELECT 
                      SCHEDULE_SEQ, FILE_EXT, FILE_NM, REALTIME_YN, UPLOAD_TIME, UPLOAD_FROM_DT, UPLOAD_FROM_TIME, UPLOAD_TO_DT, UPLOAD_TO_TIME, USE_YN
                    , PROJ_CD, FOLDER_CD, SUB_FOLDER_CD, SUB_FOLDER_NM
                FROM SCHEDULE_INFO 
                WHERE USE_YN = 'Y'";
            DataTable dt = SQLiteHelper.SelectDataSet(sql).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                // 2. 저장된 업로드기간, 실시간여부 가져오기
                System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) 2. 저장된 스케쥴정보 가져오기 = {0}, {1}, {2}, {3}, {4}", dr["FILE_EXT"].ToString(), dr["REALTIME_YN"].ToString(), dr["UPLOAD_TIME"].ToString(), dr["UPLOAD_FROM_DT"].ToString(), dr["UPLOAD_FROM_TIME"].ToString()));

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
                    //if (dr["REALTIME_YN"].ToString().Equals("Y") || Math.Abs(tsGap.TotalSeconds) < 30)
                    if (dr["REALTIME_YN"].ToString().Equals("Y") || (0 < tsGap.TotalSeconds && tsGap.TotalSeconds < 30))
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) 4 실시간 이거나, 1일1회 업로드시간에 해당될 경우"));

                        // 5. 임시감시폴더에 데이터 있는지 체크
                        DirectoryInfo di = new DirectoryInfo(autoTempFolder);
                        int iFileCnt = di.GetFiles().Length;
                        foreach (FileInfo fi in di.GetFiles("*", SearchOption.AllDirectories))
                        {
                            // 6. 확장자 및 파일시작명 동일한 파일일 경우만 진행
                            if (fi.Extension.ToLower().Equals("." + dr["FILE_EXT"].ToString()) && fi.Name.IndexOf(dr["FILE_NM"].ToString()) == 0)
                            {
                                System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) 5. 감시폴더에 데이터 있는지 체크 = {0}, {1}, {2}, {3}", fi.Name, fi.Length, fi.CreationTime, fi.Exists));
                                try
                                {
                                    // 7. FTP 전송
                                    System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) 7. FTP 전송"));
                                    JObject ftpResult = FTPApi.Upload("http://" + Global.svrUrl + "/api/sdms/insertFile.do", "clientSeq=" + Global.clientSeq + "&subFolderCd=" + dr["SUB_FOLDER_CD"].ToString() + "&userId=" + Global.userId, fi.FullName);
                                    //throw new Exception("FTP전송 실패");

                                    // 8. 서버에 파일정보 전송하기
                                    System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) 8. 서버에 전송이력 전송하기"));
                                    // set req params
                                    var reqParams = new JObject();
                                    reqParams.Add("fileInfPk", ftpResult["fileInfPk"].ToString());
                                    reqParams.Add("subFolderCd", dr["SUB_FOLDER_CD"].ToString());
                                    reqParams.Add("clientSeq", Global.clientSeq);
                                    reqParams.Add("comCd", Global.comCd);
                                    reqParams.Add("plantCd", Global.plantCd);
                                    reqParams.Add("fileDiv", fi.Extension.Substring(1));
                                    reqParams.Add("fileRegDt", fi.CreationTime.ToShortDateString().Replace("-", ""));
                                    reqParams.Add("fileSize", fi.Length);
                                    reqParams.Add("orgFileNm", fi.Name);
                                    reqParams.Add("orgPath", Global.clientWatchFolder.Substring(3) + fi.DirectoryName.Replace(autoTempFolder, ""));
                                    reqParams.Add("transDt", dtNow.ToString("yyyy-MM-dd HH:mm:ss"));
                                    reqParams.Add("regDt", dtNow.ToString("yyyy-MM-dd HH:mm:ss"));
                                    reqParams.Add("regId", Global.userPk);
                                    reqParams.Add("regIp", Global.clientIP);
                                    reqParams.Add("modDt", dtNow.ToString("yyyy-MM-dd HH:mm:ss"));
                                    reqParams.Add("modId", Global.userPk);
                                    reqParams.Add("modIp", Global.clientIP);
                                    // call api
                                    string targetUrl = "http://" + Global.svrUrl + "/api/sdms/insertFileInfoSDMS.do";
                                    JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);

                                    // 9. 전송된 파일은 삭제
                                    fi.Delete();

                                    // 10. 로컬 DB에 성공 로그 남기기
                                    System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) 10. 로컬 DB에 성공 로그 남기기"));
                                    sql = string.Format(@"INSERT INTO TRANS_HISTORY 
                                        (AUTO_YN, FILE_NM, FILE_SIZE, REG_ID, REG_DT, TRANS_YN, TRY_CNT, SVR_TRANS_DT, SEND_LOC, REV_SUB_FOLDER, SUB_FOLDER_CD)
                                        VALUES 
                                        ('Y', '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}', '{9}')"
                                            , fi.Name
                                            , fi.Length
                                            , Global.userId
                                            , fi.CreationTime
                                            , "Success"
                                            , 1
                                            , dtNow.ToString("yyyy-MM-dd HH:mm:ss")
                                            , Global.clientWatchFolder + fi.DirectoryName.Replace(autoTempFolder, "")
                                            , dr["SUB_FOLDER_NM"].ToString()
                                            , dr["SUB_FOLDER_CD"].ToString()
                                            );
                                    SQLiteHelper.SaveData(sql);
                                }
                                catch (Exception ex)
                                {
                                    // 10. 로컬 DB에 실패 로그 남기기
                                    System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) 10. 로컬 DB에 실패 로그 남기기"));
                                    sql = string.Format(@"INSERT INTO TRANS_HISTORY 
                                        (AUTO_YN, FILE_NM, FILE_SIZE, REG_ID, REG_DT, TRANS_YN, TRY_CNT, SVR_TRANS_DT, SEND_LOC, REV_SUB_FOLDER, FAIL_REASON, SUB_FOLDER_CD)
                                        VALUES 
                                        ('Y', '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}', '{9}', '{10}')"
                                            , fi.Name
                                            , fi.Length
                                            , Global.userId
                                            , fi.CreationTime
                                            , "Fail"
                                            , 1
                                            , dtNow.ToString()
                                            , Global.clientWatchFolder + fi.DirectoryName.Replace(autoTempFolder, "")
                                            , dr["SUB_FOLDER_NM"].ToString()
                                            , ex.Message
                                            , dr["SUB_FOLDER_CD"].ToString()
                                            );
                                    SQLiteHelper.SaveData(sql);

                                    // 11. 실패된 파일 실패폴더로 옮기기
                                    System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm:timer) 11. 실패된 파일 실패폴더로 옮기기"));

                                    string failTempFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\SDMSConnector\FailTemp\";
                                    if (!Directory.Exists(failTempFolder))
                                        Directory.CreateDirectory(failTempFolder);

                                    fi.MoveTo(failTempFolder + fi.Name);
                                    System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm:timer) dest = {0}", failTempFolder));
                                }
                            }
                        }

                        // parser 호출 - 파일이 있을 경우만 호출
                        if (iFileCnt > 0)
                        {
                            var reqParseParams = new JObject();
                            string targetParseUrl = "http://" + Global.svrUrl + "/api/sdms/reportParse.do";
                            RestApiRequest.CallAsync(reqParseParams, targetParseUrl);
                        }
                    }
                }
            }

            System.Diagnostics.Debug.WriteLine(string.Format("kstimer(MainForm:timer) 타이머 종료 = {0}", DateTime.Now.ToLongTimeString()));
            timer.Enabled = true;
        }

        #endregion
    }
}
