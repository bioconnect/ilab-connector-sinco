using LSP.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace sdms_connector
{
    public partial class DataHistory : Form
    {

        public DataHistory()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(DataHistory) init!"));

            InitializeComponent();

            // 조회 버튼 가운데 정렬
            SetPositionSearchBtn();

            // 검색날짜 초기 셋팅
            DateTime nowDt = DateTime.Now;
            dtpFrom.Value = nowDt.AddMonths(-1);

            // 그리드 컬럼 초기화
            SetGridView();

            // 그리드 색 변경
            dgvTransHistory.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 208, 237);
            dgvTransHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 208, 237);
            dgvTransHistory.DefaultCellStyle.SelectionForeColor = Color.Black;

            // 다국어적용
            label1.Text = Global.GetMultiLang("E-TXT-DATA_HISTORY", "데이터이력");
            label4.Text = Global.GetMultiLang("E-TXT-FILE_NAME", "파일명");
            label5.Text = Global.GetMultiLang("E-TXT-UPLOAD_DT", "업로드 일시");
            btnSearch.Text = Global.GetMultiLang("E-TXT-SEARCH", "조회");
        }

        #region method
        // 그리드 컬럼 초기화
        private void SetGridView()
        {
            // 불필요한 컬럼은 안보이도록 처리
            dgvTransHistory.Columns["SUB_FOLDER_CD"].Visible = false;
            dgvTransHistory.Columns["AUTO_YN"].Visible = false;
            dgvTransHistory.Columns["REG_ID"].Visible = false;

            // 컬럼명
            dgvTransHistory.Columns["AUTO_YN_NM"].HeaderText = Global.GetMultiLang("E-TXT-AUTO_MANUAL", "자동/수동");
            dgvTransHistory.Columns["FILE_NM"].HeaderText = Global.GetMultiLang("E-TXT-FILE_NAME", "파일명");
            dgvTransHistory.Columns["FILE_SIZE"].HeaderText = Global.GetMultiLang("E-TXT-FILE_SIZE", "파일크기");
            dgvTransHistory.Columns["REG_ID"].HeaderText = Global.GetMultiLang("E-TXT-REG_ID", "생성자");
            dgvTransHistory.Columns["REG_DT"].HeaderText = Global.GetMultiLang("E-TXT-REG_DT", "생성일시");
            dgvTransHistory.Columns["TRANS_YN"].HeaderText = Global.GetMultiLang("E-TXT-SEND_YN", "전송여부");
            dgvTransHistory.Columns["TRY_CNT"].HeaderText = Global.GetMultiLang("E-TXT-TRY_CNT", "시도횟수");
            dgvTransHistory.Columns["TRY_AGAIN"].HeaderText = Global.GetMultiLang("E-TXT-RETRY", "재전송");
            dgvTransHistory.Columns["SVR_TRANS_DT"].HeaderText = Global.GetMultiLang("E-TXT-SERVER_SEND_DT", "서버전송일시");
            dgvTransHistory.Columns["SEND_LOC"].HeaderText = Global.GetMultiLang("E-TXT-SEND_LOC", "발신위치");
            dgvTransHistory.Columns["REV_SUB_FOLDER"].HeaderText = Global.GetMultiLang("E-TXT-REV_SUBFOLDER", "수신서브폴더");
            dgvTransHistory.Columns["FAIL_REASON"].HeaderText = Global.GetMultiLang("E-TXT-FAIL_REASON", "실패사유");
            dgvTransHistory.Columns["SUB_FOLDER_CD"].HeaderText = Global.GetMultiLang("E-TXT-SUBFOLDER_CD", "서브폴더코드");

            // 가로폭
            dgvTransHistory.Columns["AUTO_YN"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTransHistory.Columns["FILE_NM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTransHistory.Columns["FILE_SIZE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTransHistory.Columns["REG_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTransHistory.Columns["REG_DT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTransHistory.Columns["TRANS_YN"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTransHistory.Columns["TRY_CNT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTransHistory.Columns["TRY_AGAIN"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTransHistory.Columns["SVR_TRANS_DT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTransHistory.Columns["SEND_LOC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTransHistory.Columns["REV_SUB_FOLDER"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTransHistory.Columns["FAIL_REASON"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        // 데이터이력 조회
        private void SelectDataHistory()
        {
            // selelct
            string sql = string.Format(@"
                        SELECT 
                              AUTO_YN
                            , CASE AUTO_YN WHEN 'Y' THEN '자동' ELSE '수동' END AS AUTO_YN_NM
                            , FILE_NM, FILE_SIZE, REG_ID, REG_DT, TRANS_YN, TRY_CNT, '' AS TRY_AGAIN, SVR_TRANS_DT, SEND_LOC, REV_SUB_FOLDER, FAIL_REASON
                            , SUB_FOLDER_CD
                        FROM TRANS_HISTORY
                        WHERE strftime('%s','{0}') <= strftime('%s',substr(SVR_TRANS_DT,0,11)) AND strftime('%s',substr(SVR_TRANS_DT,0,11)) <= strftime('%s','{1}')"
                , dtpFrom.Value.ToShortDateString(), dtpTo.Value.ToShortDateString());
            if (!String.IsNullOrEmpty(tbFileNm.Text))
                sql += string.Format(" AND FILE_NM LIKE '%{0}%'", tbFileNm.Text);
            sql += " ORDER BY TRANS_SEQ DESC";
            DataTable dt = SQLiteHelper.SelectDataSet(sql).Tables[0];

            // 그리드 바인딩
            //dgvTransHistory.DataSource = null;
            //dgvTransHistory.DataSource = SQLiteHelper.SelectDataSet(sql).Tables[0];
            dgvTransHistory.Rows.Clear();

            string AUTO_YN;
            string AUTO_YN_NM;
            string FILE_NM;
            string FILE_SIZE;
            string REG_ID;
            string REG_DT;
            string TRANS_YN;
            string TRY_CNT;
            string TRY_AGAIN;
            string SVR_TRANS_DT;
            string SEND_LOC;
            string REV_SUB_FOLDER;
            string FAIL_REASON;
            string SUB_FOLDER_CD;

            int nRow = 0;
            foreach (DataRow dr in dt.Rows)
            {
                AUTO_YN = dr["AUTO_YN"].ToString();
                AUTO_YN_NM = dr["AUTO_YN_NM"].ToString();
                FILE_NM = dr["FILE_NM"].ToString();
                FILE_SIZE = dr["FILE_SIZE"].ToString();
                REG_ID = dr["REG_ID"].ToString();
                REG_DT = dr["REG_DT"].ToString();
                TRANS_YN = dr["TRANS_YN"].ToString();
                TRY_CNT = dr["TRY_CNT"].ToString();
                TRY_AGAIN = dr["TRY_AGAIN"].ToString();
                SVR_TRANS_DT = dr["SVR_TRANS_DT"].ToString();
                SEND_LOC = dr["SEND_LOC"].ToString();
                REV_SUB_FOLDER = dr["REV_SUB_FOLDER"].ToString();
                FAIL_REASON = dr["FAIL_REASON"].ToString();
                SUB_FOLDER_CD = dr["SUB_FOLDER_CD"].ToString();

                // 라인 추가
                nRow = dgvTransHistory.Rows.Add(AUTO_YN, AUTO_YN_NM, FILE_NM, FILE_SIZE, REG_ID, REG_DT, TRANS_YN, TRY_CNT, TRY_AGAIN, SVR_TRANS_DT, SEND_LOC, REV_SUB_FOLDER, FAIL_REASON, SUB_FOLDER_CD);

                if (TRANS_YN.Equals("Fail") && TRY_CNT.Equals("1") && AUTO_YN.Equals("Y"))
                {
                    dgvTransHistory.Rows[nRow].Cells["TRY_AGAIN"].Value = "재전송";
                    dgvTransHistory.Rows[nRow].Cells["TRY_AGAIN"].Style.ForeColor = Color.Red;
                }
                else if (TRANS_YN.Equals("Fail") && TRY_CNT.Equals("2"))
                {
                    dgvTransHistory.Rows[nRow].Cells["TRY_AGAIN"].Value = "관리자문의";
                    dgvTransHistory.Rows[nRow].Cells["TRY_AGAIN"].Style.ForeColor = Color.Gray;
                    dgvTransHistory.Rows[nRow].Cells["TRY_AGAIN"].ReadOnly = true;
                }
            }

            dgvTransHistory.ClearSelection();
            dgvTransHistory.Columns["AUTO_YN_NM"].MinimumWidth = 90;
            dgvTransHistory.Columns["FILE_NM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTransHistory.Columns["FILE_SIZE"].MinimumWidth = 80;
            dgvTransHistory.Columns["REG_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTransHistory.Columns["REG_DT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTransHistory.Columns["TRANS_YN"].MinimumWidth = 80;
            dgvTransHistory.Columns["TRY_CNT"].MinimumWidth = 80;
            dgvTransHistory.Columns["TRY_AGAIN"].MinimumWidth = 80;
            dgvTransHistory.Columns["SVR_TRANS_DT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTransHistory.Columns["SEND_LOC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTransHistory.Columns["REV_SUB_FOLDER"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTransHistory.Columns["FAIL_REASON"].MinimumWidth = 80;
        }

        // 조회 버튼 가운데 정렬
        private void SetPositionSearchBtn()
        {
            btnSearch.Left = (this.ClientSize.Width - btnSearch.Width) / 2;
            //btnSearch.Top = (this.ClientSize.Height - btnSearch.Height) / 2;
        }
        #endregion

        #region  이벤트
        // 조회버튼 클릭시
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SelectDataHistory();
        }

        // 폼 크기 변경시
        private void DataHistory_Resize(object sender, EventArgs e)
        {
            // 조회 버튼 가운데 정렬
            SetPositionSearchBtn();
        }
        #endregion

        #region 그리드 이벤트
        // 데이터 바인딩후
        private void dgvTransHistory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // 한줄 선택 삭제
            dgvTransHistory.ClearSelection();
        }

        // 셀 클릭시 - 재전송 처리
        private void dgvTransHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow dr = dgvTransHistory.Rows[e.RowIndex];

            if (e.ColumnIndex == 8 && dgvTransHistory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("재전송"))
            {
                try
                {
                    DialogResult mb = MessageBox.Show("재전송 진행하시겠습니까?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (mb == DialogResult.Cancel)
                    {
                        return;
                    }

                    // 0. 파일정보 읽기
                    string failFile = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\SDMSConnector\FailTemp\" + dr.Cells["FILE_NM"].Value.ToString();
                    FileInfo fi = new FileInfo(failFile);

                    if (!fi.Exists)
                    {
                        throw new Exception("파일이 존재하지 않습니다.");
                    }

                    // 1. FTP 전송
                    System.Diagnostics.Debug.WriteLine(string.Format("kskang dgvTransHistory_CellClick 1. FTP 전송"));
                    JObject ftpResult = FTPApi.Upload("http://" + Global.svrUrl + "/api/sdms/insertFile.do", "clientSeq=" + Global.clientSeq + "&subFolderCd=" + dr.Cells["SUB_FOLDER_CD"].Value.ToString() + "&userId=" + Global.userId, fi.FullName);

                    // 2. 서버에 파일정보 전송하기
                    System.Diagnostics.Debug.WriteLine(string.Format("kskang dgvTransHistory_CellClick 2. 서버에 전송이력 전송하기 = {0}", fi.FullName));
                    // set req params
                    var reqParams = new JObject();
                    reqParams.Add("fileInfPk", ftpResult["fileInfPk"].ToString());
                    reqParams.Add("subFolderCd", dr.Cells["SUB_FOLDER_CD"].Value.ToString());
                    reqParams.Add("clientSeq", Global.clientSeq);
                    reqParams.Add("comCd", Global.comCd);
                    reqParams.Add("plantCd", Global.plantCd);
                    reqParams.Add("fileDiv", fi.Extension.Substring(1));
                    reqParams.Add("fileRegDt", dr.Cells["REG_DT"].Value.ToString());
                    reqParams.Add("fileSize", dr.Cells["FILE_SIZE"].Value.ToString());
                    reqParams.Add("orgFileNm", dr.Cells["FILE_NM"].Value.ToString());
                    reqParams.Add("orgPath", dr.Cells["SEND_LOC"].Value.ToString().Substring(3));
                    reqParams.Add("transDt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    reqParams.Add("regDt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    reqParams.Add("regId", Global.userPk);
                    reqParams.Add("regIp", Global.clientIP);
                    reqParams.Add("modDt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    reqParams.Add("modId", Global.userPk);
                    reqParams.Add("modIp", Global.clientIP);

                    // call api
                    string targetUrl = "http://" + Global.svrUrl + "/api/sdms/insertFileInfoSDMS.do";
                    JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);

                    // 3. 전송된 파일은 삭제
                    System.Diagnostics.Debug.WriteLine(string.Format("kskang dgvTransHistory_CellClick 3. 전송된 파일은 삭제"));
                    fi.Delete();

                    // 4. 로컬 DB에 성공 로그 업데이트
                    System.Diagnostics.Debug.WriteLine(string.Format("kskan dgvTransHistory_CellClick 4. 로컬 DB에 성공 로그 업데이트"));
                    string sql = string.Format(@"UPDATE TRANS_HISTORY SET TRANS_YN = '{0}', TRY_CNT = 2 WHERE FILE_NM = '{1}'"
                            , "Success"
                            , dr.Cells["FILE_NM"].Value.ToString());
                    SQLiteHelper.SaveData(sql);

                    MessageBox.Show(Global.GetMultiLang("E-MSG-SAVE_OK", "정상적으로 저장 되었습니다."));
                }
                catch (Exception ex)
                {
                    // 4. 로컬 DB에 실패 로그 업데이트
                    System.Diagnostics.Debug.WriteLine(string.Format("kskan dgvTransHistory_CellClick 4. 로컬 DB에 실패 로그 업데이트"));
                    string sql = string.Format(@"UPDATE TRANS_HISTORY SET TRANS_YN = '{0}', TRY_CNT = 2, FAIL_REASON = '{1}' WHERE FILE_NM = '{2}'"
                            , "Fail"
                            , ex.Message
                            , dr.Cells["FILE_NM"].Value.ToString()); ;
                    SQLiteHelper.SaveData(sql);

                    MessageBox.Show(ex.Message, "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // parser 호출
                var reqParseParams = new JObject();
                string targetParseUrl = "http://" + Global.svrUrl + "/api/sdms/reportParse.do";
                RestApiRequest.CallAsync(reqParseParams, targetParseUrl);

                SelectDataHistory();
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void panSearch_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion
    }

}
