using LSP.Common;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sdms_connector
{
    public partial class PdfForm : Form
    {
        // 메인폼에 전달하는 이벤트핸들러 - 저장, 취소 후 메인폼 전환 및 최소화 처리
        public delegate void FrmSendDataHandler(Object obj);
        public event FrmSendDataHandler FrmSendEvent;

        // 서브폴더 선택 정보
        public string projCd;
        public string folderCd;
        public string subfolderCd;
        public string subfolderNm;

        // 수동 저장된 파일 정보
        private FileInfo fiPdf = null;
        private FileInfo fiRaw = null;

        public PdfForm(string fileFullPath)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(PdfForm) init! "));
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(PdfForm) fileFullPath = {0}", fileFullPath));
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(PdfForm) Global.clientWatchFolder = {0}", Global.clientWatchFolder));

            // raw, pdf 파일 분리
            string[] fileResult = fileFullPath.Split(new char[] { '|' });
            fiRaw = new FileInfo(Global.clientWatchFolder + @"\" + fileResult[0].ToString());
            fiPdf = new FileInfo(fileResult[1].ToString());

            System.Diagnostics.Debug.WriteLine(string.Format("kskang(PdfForm) fiRaw.FullName,fiRaw.Exists = {0}, {1}", fiRaw.FullName, fiRaw.Exists));
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(PdfForm) fiPdf.FullName, fiPdf.Exists = {0}, {1}", fiPdf.FullName, fiPdf.Exists));

            InitializeComponent();

            // clawPDF로 저장된 파일 정보 쓰기
            ProcFile(fileResult[0]);

            // 사용자 정보 출력
            lblPrivateInfo.Text = Global.deptNm + " " + Global.teamNm + " " + Global.userNm;

            // 그리드 색 변경
            dgvField.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 208, 237);
            dgvField.DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 208, 237);
            dgvField.DefaultCellStyle.SelectionForeColor = Color.Black;

            // 다국어적용
            label8.Text = Global.GetMultiLang("E-TXT-CLIENT_ID", "클라이언트ID");
            label4.Text = Global.GetMultiLang("E-TXT-REG_ID", "생성자");
            label3.Text = Global.GetMultiLang("E-TXT-FILE_NAME", "파일명");
            label5.Text = Global.GetMultiLang("E-TXT-REG_DT", "생성일시");
            label6.Text = Global.GetMultiLang("E-TXT-FILE_SIZE", "파일크기");
            label9.Text = Global.GetMultiLang("E-TXT-SUBFOLDER_SEL", "서브폴더선택");
            btnSave.Text = Global.GetMultiLang("E-TXT-SAVE", "저장");
            btnCancle.Text = Global.GetMultiLang("E-TXT-CANCLE", "취소");
        }

        #region method
        // clawPDF로 저장된 파일 정보 쓰기
        private void ProcFile(string fileFullPath)
        {
            //fiPdf = new FileInfo(fileFullPath);

            // 2. 파일정보 읽기
            lblFileNm.Text = fiPdf.Name;
            lblFileCreateTime.Text = fiPdf.CreationTime.ToString();
            lblFileSize.Text = fiPdf.Length + " Bytes";

            lblClientID.Text = Global.clientID;
            lblUserNm.Text = Global.userNm;
        }

        // 필드리스트 조회 후 그리드 셋팅
        private void MakeFieldList()
        {
            // set req params
            var reqParams = new JObject();
            reqParams.Add("comCd", Global.comCd);
            reqParams.Add("plantCd", Global.plantCd);
            reqParams.Add("subFolderCd", subfolderCd);

            // call api
            string targetUrl = "http://" + Global.svrUrl + "/api/sdms/selelctFieldList.do";
            JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);
            // 테스트데이터
            //String result = "{\"result\":\"success\",\"msg\":\"\",\"data\":{\"contents\":[{\"fieldCd\":19,\"subFolderCd\":7,\"fieldNm\":\"필드명1\",\"fieldFormat\":\"List\",\"fieldSize\":11,\"value\":{\"listVal\":[{\"lstCd\":\"1\",\"lstNm\":\"리스트1\"},{\"lstCd\":\"2\",\"lstNm\":\"리스트2\"},{\"lstCd\":\"3\",\"lstNm\":\"리스트3\"},{\"lstCd\":\"4\",\"lstNm\":\"리스트4\"}]},\"autoincYn\":\"N\",\"mandYn\":\"Y\"},{\"fieldCd\":20,\"subFolderCd\":7,\"fieldNm\":\"필드명2\",\"fieldFormat\":\"Numeric\",\"fieldSize\":10,\"value\":\"0\",\"autoincYn\":\"N\",\"mandYn\":\"Y\"},{\"fieldCd\":21,\"subFolderCd\":7,\"fieldNm\":\"필드명3\",\"fieldFormat\":\"List\",\"fieldSize\":1,\"value\":{\"listVal\":[{\"lstCd\":\"5\",\"lstNm\":\"분석법1\"},{\"lstCd\":\"6\",\"lstNm\":\"분석법2\"},{\"lstCd\":\"7\",\"lstNm\":\"분석법3\"}]},\"autoincYn\":\"N\",\"mandYn\":\"Y\"},{\"fieldCd\":22,\"subFolderCd\":7,\"fieldNm\":\"필드명4\",\"fieldFormat\":\"Text\",\"fieldSize\":222,\"value\":\"텍스트기본값\",\"autoincYn\":\"N\",\"mandYn\":\"Y\"}]}}";
            //JObject resultJson = JObject.Parse(result);

            #region 그리드 생성
            //dgvField.DataSource = null;
            dgvField.Rows.Clear();



            string fieldCd;
            string fieldNm;
            string fieldFormat;
            int fieldSize;
            string value;
            string autoincYn;
            string mandYn;

            int nRow = 0;
            foreach (JObject data in resultJson["data"])
            {
                fieldCd = data["fieldCd"].ToString();
                fieldNm = data["fieldNm"].ToString();
                fieldFormat = data["fieldFormat"].ToString();
                fieldSize = int.Parse(data["fieldSize"].ToString());
                value = data["value"].ToString();
                autoincYn = data["autoincYn"].ToString();
                mandYn = data["mandYn"].ToString();

                // row 생성 - 리스트 일 경우 콤보박스 생성
                if (fieldFormat.Equals("List"))
                {
                    nRow = dgvField.Rows.Add(fieldCd, fieldNm, fieldFormat, fieldSize, null, autoincYn, mandYn);

                    // 콤보박스 생성
                    DataGridViewComboBoxCell cCell = new DataGridViewComboBoxCell();
                    cCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;

                    // 콤보박스값 셋팅            
                    foreach (JObject listVal in data["value"])
                    {
                        cCell.Items.Add(new ComboKeyValue(listVal["lstCd"].ToString(), listVal["lstNm"].ToString()));
                    }
                    cCell.DisplayMember = "ComboValue";
                    cCell.ValueMember = "ComboValue";

                    // 콤보박스 기존쉘에 셋팅
                    dgvField.Rows[nRow].Cells["value"] = cCell;
                }
                else if (fieldFormat.Equals("Numeric"))
                {
                    nRow = dgvField.Rows.Add(fieldCd, fieldNm, fieldFormat, fieldSize, value, autoincYn, mandYn);

                    // set 사이즈
                    ((DataGridViewTextBoxCell)dgvField.Rows[nRow].Cells["value"]).MaxInputLength = fieldSize;

                    // set 자동증가
                    if (autoincYn.Equals("Y"))
                        dgvField.Rows[nRow].Cells["value"].ReadOnly = true;
                }
                else if (fieldFormat.Equals("Text"))
                {
                    nRow = dgvField.Rows.Add(fieldCd, fieldNm, fieldFormat, fieldSize, value, autoincYn, mandYn);

                    ((DataGridViewTextBoxCell)dgvField.Rows[nRow].Cells["value"]).MaxInputLength = fieldSize;
                }
                else if (fieldFormat.Equals("Data"))
                {
                    nRow = dgvField.Rows.Add(fieldCd, fieldNm, fieldFormat, fieldSize, null, autoincYn, mandYn);

                    // 콤보박스 생성
                    DataGridViewComboBoxCell cCell = new DataGridViewComboBoxCell();
                    cCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;

                    // 콤보박스값 셋팅            
                    foreach (JObject listVal in data["value"])
                    {
                        cCell.Items.Add(listVal["lstNm"].ToString());
                    }

                    // 콤보박스 기존쉘에 셋팅
                    dgvField.Rows[nRow].Cells["value"] = cCell;
                }
            }
            #endregion

            // 불필요한 컬럼은 안보이도록 처리
            dgvField.Columns["fieldCd"].Visible = false;

            // 재 바인딩시 헤더값이 초기화 되서 명시적으로 넣어줌.
            dgvField.Columns["fieldNm"].HeaderText = "필드명";
            dgvField.Columns["fieldFormat"].HeaderText = "포멧";
            dgvField.Columns["fieldSize"].HeaderText = "사이즈";
            dgvField.Columns["value"].HeaderText = "값";
            dgvField.Columns["autoincYn"].HeaderText = "자동증가";
            dgvField.Columns["mandYn"].HeaderText = "필수";

            // 컬럼사이즈
            dgvField.Columns["fieldNm"].Width = 150;
            dgvField.Columns["fieldFormat"].Width = 100;
            dgvField.Columns["fieldSize"].Width = 100;
            dgvField.Columns["value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvField.Columns["autoincYn"].Width = 100;
            dgvField.Columns["mandYn"].Width = 100;

            // 컬럼 색, 속성 설정
            dgvField.Columns["fieldNm"].ReadOnly = true;
            dgvField.Columns["fieldNm"].DefaultCellStyle.BackColor = Color.Gray;
            dgvField.Columns["fieldFormat"].ReadOnly = true;
            dgvField.Columns["fieldFormat"].DefaultCellStyle.BackColor = Color.Gray;
            dgvField.Columns["fieldSize"].ReadOnly = true;
            dgvField.Columns["fieldSize"].DefaultCellStyle.BackColor = Color.Gray;
            dgvField.Columns["autoincYn"].ReadOnly = true;
            dgvField.Columns["autoincYn"].DefaultCellStyle.BackColor = Color.Gray;
            dgvField.Columns["mandYn"].ReadOnly = true;
            dgvField.Columns["mandYn"].DefaultCellStyle.BackColor = Color.Gray;
        }

        // 저장, 취소 후 생성한 PDF 파일 삭제 및 PDF폼 닫기
        private void DelFile()
        {
            // 1. pdf 파일 삭제
            fiPdf.Delete();

            // 2. PDF폼에서 메인폼에 이벤트 전달
            this.FrmSendEvent(null);
        }
        #endregion

        #region 버튼 이벤트
        // 저장 버튼 클릭시
        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(PdfForm) btnSave_Click(value)"));

            // validation
            if (String.IsNullOrEmpty(tbSubFolderNm.Text))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-SEL_SUBFOLDER", "서브폴더를 먼저 선택해 주세요!"));
                return;
            }

            foreach (DataGridViewRow dr in dgvField.Rows)
            {
                // 필수값인데, 널이거나 공백일 경우
                if (dr.Cells["mandYn"].Value.Equals("Y") && (dr.Cells["value"].Value == null || string.IsNullOrWhiteSpace(dr.Cells["value"].Value.ToString())))
                {
                    MessageBox.Show(string.Format(@"({0})은/는 필수항목 입니다.", dr.Cells["fieldNm"].Value.ToString()));
                    return;
                }
            }

            // 저장처리
            DateTime dtNow = DateTime.Now;
            try
            {
                #region pdf 전송
                // 1. FTP 전송
                System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm:PdfForm) 1. FTP 전송"));
                JObject ftpResult = FTPApi.Upload("http://" + Global.svrUrl + "/api/sdms/insertFile.do", "clientSeq=" + Global.clientSeq + "&subFolderCd=" + subfolderCd + "&userId=" + Global.userId, fiPdf.FullName);

                // 2. 서버에 파일정보 전송하기
                // set req params
                var reqParams = new JObject();
                reqParams.Add("fileInfPk", ftpResult["fileInfPk"].ToString());
                reqParams.Add("subFolderCd", subfolderCd);
                reqParams.Add("clientSeq", Global.clientSeq);
                reqParams.Add("comCd", Global.comCd);
                reqParams.Add("plantCd", Global.plantCd);
                reqParams.Add("fileDiv", fiPdf.Extension.Substring(1));
                reqParams.Add("fileRegDt", fiPdf.CreationTime.ToShortDateString().Replace("-", ""));
                reqParams.Add("fileSize", fiPdf.Length);
                reqParams.Add("orgFileNm", fiPdf.Name);
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

                // 3. 메타데이터 전송하기
                var reqParams2 = new JObject();
                var arrMetaInfo = new JArray();
                foreach (DataGridViewRow dr in dgvField.Rows)
                {
                    var metaINfo = new JObject();
                    metaINfo.Add("fieldCd", dr.Cells["fieldCd"].Value.ToString());
                    metaINfo.Add("fileInfPk", ftpResult["fileInfPk"].ToString());

                    if (dr.Cells["value"].Value == null)
                        metaINfo.Add("value", "");
                    else
                        metaINfo.Add("value", dr.Cells["value"].Value.ToString());

                    metaINfo.Add("regDt", dtNow.ToString("yyyy-MM-dd HH:mm:ss"));
                    metaINfo.Add("regId", Global.userPk);
                    metaINfo.Add("regIp", Global.clientIP);
                    metaINfo.Add("modDt", dtNow.ToString("yyyy-MM-dd HH:mm:ss"));
                    metaINfo.Add("modId", Global.userPk);
                    metaINfo.Add("modIp", Global.clientIP);
                    metaINfo.Add("clientSeq", Global.clientSeq);

                    arrMetaInfo.Add(metaINfo);
                }
                reqParams2.Add("data", arrMetaInfo);
                reqParams2.Add("fileInfPk", ftpResult["fileInfPk"].ToString());
                // call api
                targetUrl = "http://" + Global.svrUrl + "/api/sdms/insertMetaInfo.do";
                resultJson = RestApiRequest.CallSync(reqParams2, targetUrl);
                #endregion

                #region raw 파일 전송
                if (fiRaw.Exists)
                {
                    // 1. FTP 전송
                    System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm:PdfForm) 1-2. FTP 전송"));
                    JObject ftpResult2 = FTPApi.Upload("http://" + Global.svrUrl + "/api/sdms/insertFile.do", "clientSeq=" + Global.clientSeq + "&subFolderCd=" + subfolderCd + "&userId=" + Global.userId, fiRaw.FullName);

                    // 2. 서버에 파일정보 전송하기
                    // set req params
                    var reqParams3 = new JObject();
                    reqParams3.Add("fileInfPk", ftpResult2["fileInfPk"].ToString());
                    reqParams3.Add("subFolderCd", subfolderCd);
                    reqParams3.Add("clientSeq", Global.clientSeq);
                    reqParams3.Add("comCd", Global.comCd);
                    reqParams3.Add("plantCd", Global.plantCd);
                    reqParams3.Add("fileDiv", fiRaw.Extension.Substring(1));
                    reqParams3.Add("fileRegDt", fiRaw.CreationTime.ToShortDateString().Replace("-", ""));
                    reqParams3.Add("fileSize", fiRaw.Length);
                    reqParams3.Add("orgFileNm", fiRaw.Name);
                    reqParams3.Add("transDt", dtNow.ToString("yyyy-MM-dd HH:mm:ss"));
                    reqParams3.Add("regDt", dtNow.ToString("yyyy-MM-dd HH:mm:ss"));
                    reqParams3.Add("regId", Global.userPk);
                    reqParams3.Add("regIp", Global.clientIP);
                    reqParams3.Add("modDt", dtNow.ToString("yyyy-MM-dd HH:mm:ss"));
                    reqParams3.Add("modId", Global.userPk);
                    reqParams3.Add("modIp", Global.clientIP);
                    // call api
                    string targetUrl2 = "http://" + Global.svrUrl + "/api/sdms/insertFileInfoSDMS.do";
                    JObject resultJson2 = RestApiRequest.CallSync(reqParams3, targetUrl2);
                }
                #endregion

                // 4. 로컬 DB에 성공 로그 남기기
                System.Diagnostics.Debug.WriteLine(string.Format("kskang(PdfForm) 4. 로컬 DB에 성공 로그 남기기"));
                string sql = string.Format(@"INSERT INTO TRANS_HISTORY 
                                        (AUTO_YN, FILE_NM, FILE_SIZE, REG_ID, REG_DT, TRANS_YN, TRY_CNT, SVR_TRANS_DT, SEND_LOC, REV_SUB_FOLDER)
                                        VALUES 
                                        ('N', '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')"
                        , fiPdf.Name, fiPdf.Length, Global.userPk, fiPdf.CreationTime, "Success", 1, dtNow.ToString("yyyy-MM-dd HH:mm:ss"), "수동", subfolderNm);
                SQLiteHelper.SaveData(sql);

                MessageBox.Show(Global.GetMultiLang("E-MSG-SAVE_OK", "정상적으로 저장 되었습니다."));

                // 5. 저장, 취소 후 생성한 PDF 파일 삭제 및 PDF폼 닫기 
                DelFile();
            }
            catch (Exception ex)
            {
                // 4. 로컬 DB에 실패 로그 남기기
                System.Diagnostics.Debug.WriteLine(string.Format("kskang(PdfForm) 4. 로컬 DB에 실패 로그 남기기 = " + ex.ToString()));
                string sql = string.Format(@"INSERT INTO TRANS_HISTORY 
                                        (AUTO_YN, FILE_NM, FILE_SIZE, REG_ID, REG_DT, TRANS_YN, TRY_CNT, SVR_TRANS_DT, SEND_LOC, REV_SUB_FOLDER, FAIL_REASON)
                                        VALUES 
                                        ('N', '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}', '{9}')"
                        , fiPdf.Name, fiPdf.Length, Global.userPk, fiPdf.CreationTime, "Fail", 1, dtNow.ToString(), "수동", subfolderNm, ex.Message);
                SQLiteHelper.SaveData(sql);

                MessageBox.Show(ex.Message, "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // parser 호출
            var reqParseParams = new JObject();
            string targetParseUrl = "http://" + Global.svrUrl + "/api/sdms/reportParse.do";
            RestApiRequest.CallAsync(reqParseParams, targetParseUrl);
        }

        // 취소버튼 클릭시
        private void btnCancle_Click(object sender, EventArgs e)
        {
            // 저장, 취소 후 생성한 PDF 파일 삭제 및 PDF폼 닫기 
            DelFile();
        }

        // 서브폴더검색 버튼 클릭시
        private void btnSearchSubFolder_Click(object sender, EventArgs e)
        {
            SubFolderPop subFolderPop = new SubFolderPop("pdfFrm");
            subFolderPop.ShowDialog(this);

            tbSubFolderNm.Text = subfolderNm;

            // 필드리스트 조회 후 그리드 셋팅
            MakeFieldList();
        }
        #endregion

        #region 그리드 이벤트
        private void dgvField_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(PdfForm) dgvField_CellValueChanged = {0}", e.RowIndex));

            if (e.RowIndex > 0)
            {
                // 숫자 필드일 경우
                if (dgvField.Rows[e.RowIndex].Cells["fieldFormat"].Value.ToString().Equals("Numeric") && dgvField.Rows[e.RowIndex].Cells["value"].Value != null)
                {
                    int chkNum = 0;
                    bool isNum = int.TryParse(dgvField.Rows[e.RowIndex].Cells["value"].Value.ToString(), out chkNum);

                    if (!isNum)
                    {
                        MessageBox.Show(string.Format(@"({0})은/는 숫자만 입력 가능 합니다.", dgvField.Rows[e.RowIndex].Cells["fieldNm"].Value.ToString()));
                        dgvField.Rows[e.RowIndex].Cells["value"].Value = null;
                    }
                }
            }
        }
        #endregion
    }

    #region 메타데이터 콤보박스 key, value 
    public class ComboKeyValue
    {
        private String m_ComboKey;
        private String m_ComboValue;

        public ComboKeyValue(String key, String value)
        {
            ComboKey = key;
            ComboValue = value;
        }

        public String ComboKey
        {
            get { return m_ComboKey; }
            set { m_ComboKey = value; }
        }

        public String ComboValue
        {
            get { return m_ComboValue; }
            set { m_ComboValue = value; }
        }
    }
    #endregion
}
