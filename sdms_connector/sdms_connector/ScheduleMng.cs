using LSP.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sdms_connector
{
    public partial class ScheduleMng : Form
    {
        public string projCd;
        public string folderCd;
        public string subfolderCd;
        public string subfolderNm;
        private string svrPk = "0";

        public ScheduleMng()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(ScheduleMng) init!"));

            InitializeComponent();

            // 스케쥴그리드 정보 불러오기
            MakeScheduleGrid();

            // 그리드 색 변경
            dgvSchedule.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 208, 237);
            dgvSchedule.DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 208, 237);
            dgvSchedule.DefaultCellStyle.SelectionForeColor = Color.Black;

            // 다국어적용
            //label1.Text = Global.GetMultiLang("E-TXT-SCHEDULE", "스케쥴");
            //label2.Text = Global.GetMultiLang("E-TXT-SCHEDULE_LIST", "스케쥴 목록");
            //label3.Text = Global.GetMultiLang("E-TXT-SCHEDULE_INFO", "스케쥴 정보");

            /*label8.Text = Global.GetMultiLang("E-TXT-NAME_PATTERN", "이름 패턴");
            label10.Text = Global.GetMultiLang("E-TXT-UPLOAD_DT", "업로드 시점");
            label9.Text = Global.GetMultiLang("E-TXT-UPLOAD_PERIOD", "업로드 기간");
            label4.Text = Global.GetMultiLang("E-TXT-ACTIVE_YN", "활성화 여부");
            label5.Text = Global.GetMultiLang("E-TXT-SUBFOLDER_SEL", "서브폴더 선택");

            label6.Text = Global.GetMultiLang("E-TXT-FILE_EXT", "확장자");
            label7.Text = Global.GetMultiLang("E-TXT-FILE_NAME_FIRST_NAME", "파일명(시작이름)");
            rbRealtime.Text = Global.GetMultiLang("E-TXT-REALTIME", "실시간");
            rbOneAday.Text = Global.GetMultiLang("E-TXT-ONETIME", "1회/1일");
            //label1.Text = Global.GetMultiLang("E-TXT-START", "시작");
            label13.Text = Global.GetMultiLang("E-TXT-END", "종료");
            rbActivate.Text = Global.GetMultiLang("E-TXT-ACTIVE", "활성화");
            rbDeactivate.Text = Global.GetMultiLang("E-TXT-DEACTIVE", "비활성화");

            btnNew.Text = Global.GetMultiLang("E-TXT-ADD", "추가");
            btnSave.Text = Global.GetMultiLang("E-TXT-SAVE", "저장");
            btnDelete.Text = Global.GetMultiLang("E-TXT-DELETE", "삭제");*/
        }

        #region method
        // 스케쥴그리드 정보 불러오기
        private void MakeScheduleGrid()
        {
            string sql = @"SELECT 
                      SCHEDULE_SEQ
                    , FILE_EXT
                    , FILE_NM
                    , REALTIME_YN
                    , UPLOAD_TIME
                    , CASE REALTIME_YN WHEN 'Y' THEN '실시간' ELSE UPLOAD_TIME END AS REALTIME

                    , UPLOAD_FROM_DT
                    , UPLOAD_FROM_TIME
                    , UPLOAD_FROM_DT || ' ' || UPLOAD_FROM_TIME AS UPLOAD_FROM

                    , UPLOAD_TO_DT
                    , UPLOAD_TO_TIME
                    , UPLOAD_TO_DT || ' ' || UPLOAD_TO_TIME AS UPLOAD_TO

                    , USE_YN
                    , CASE USE_YN WHEN 'Y' THEN '활성화' ELSE '비활성화' END AS USE

                    , PROJ_CD
                    , FOLDER_CD
                    , SUB_FOLDER_CD
                    , SUB_FOLDER_NM 
                    , SVR_PK
                FROM SCHEDULE_INFO";
            DataTable dt = SQLiteHelper.SelectDataSet(sql).Tables[0];

            // 그리드 바인딩
            dgvSchedule.DataSource = null;
            dgvSchedule.DataSource = dt;

            // 불필요한 컬럼은 안보이도록 처리
            dgvSchedule.Columns["SCHEDULE_SEQ"].Visible = false;
            dgvSchedule.Columns["REALTIME_YN"].Visible = false;
            dgvSchedule.Columns["UPLOAD_TIME"].Visible = false;
            dgvSchedule.Columns["UPLOAD_FROM_DT"].Visible = false;
            dgvSchedule.Columns["UPLOAD_FROM_TIME"].Visible = false;
            dgvSchedule.Columns["UPLOAD_TO_DT"].Visible = false;
            dgvSchedule.Columns["UPLOAD_TO_TIME"].Visible = false;
            dgvSchedule.Columns["USE_YN"].Visible = false;
            dgvSchedule.Columns["PROJ_CD"].Visible = false;
            dgvSchedule.Columns["FOLDER_CD"].Visible = false;
            dgvSchedule.Columns["SUB_FOLDER_CD"].Visible = false;
            dgvSchedule.Columns["SVR_PK"].Visible = false;

            // 저장, 삭제후 다시 바인딩시 헤더값이 초기화 되서 명시적으로 넣어줌.
            dgvSchedule.Columns["FILE_EXT"].HeaderText = Global.GetMultiLang("E-TXT-FILE_EXT", "파일 확장자");
            dgvSchedule.Columns["FILE_NM"].HeaderText = Global.GetMultiLang("E-TXT-FILE_NAME", "파일명");
            dgvSchedule.Columns["REALTIME"].HeaderText = Global.GetMultiLang("E-TXT-UPLOAD_DT", "업로드 시점");
            dgvSchedule.Columns["UPLOAD_FROM"].HeaderText = Global.GetMultiLang("E-TXT-UPLOAD_TIME", "업로드 시작");
            dgvSchedule.Columns["UPLOAD_TO"].HeaderText = Global.GetMultiLang("E-TXT-UPLOAD_END", "업로드 종료");
            dgvSchedule.Columns["USE"].HeaderText = "활성화 여부";
            dgvSchedule.Columns["SUB_FOLDER_NM"].HeaderText = Global.GetMultiLang("E-TXT-SUBFOLDER", "서브폴더");

            dgvSchedule.Columns["FILE_EXT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSchedule.Columns["FILE_NM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSchedule.Columns["REALTIME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSchedule.Columns["UPLOAD_FROM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSchedule.Columns["UPLOAD_TO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSchedule.Columns["USE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSchedule.Columns["SUB_FOLDER_NM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        // 스케쥴정보 입력폼들 초기화
        private void ResetScheduleInfo()
        {
            hiddenScheduleSeq.Text = "0";
            tbFileExt.Text = string.Empty;
            tbFileNm.Text = string.Empty;
            rbActivate.Checked = true;
            dtpUploadTime.ResetText();
            dtpUploadFromDt.ResetText();
            dtpUploadFromTime.ResetText();
            dtpUploadToDt.ResetText();
            dtpUploadToTime.ResetText();
            rbActivate.Checked = true;
            tbSubFolderNm.Text = string.Empty;
            svrPk = "0";
        }
        #endregion

        #region 이벤트
        // 업로드시점 라디오 버튼 클릭시
        private void rbRealtime_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRealtime.Checked)
                dtpUploadTime.Enabled = false;
            else
                dtpUploadTime.Enabled = true;
        }

        // 추가 버튼 클릭시
        private void btnNew_Click(object sender, EventArgs e)
        {
            // 스케쥴정보 입력폼들 초기화
            ResetScheduleInfo();

            tbFileExt.Focus();
        }

        // 저장버튼 클릭시
        private void btnSave_Click(object sender, EventArgs e)
        {
            // validation
            if (String.IsNullOrEmpty(tbFileExt.Text))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "파일확장자", "파일확장자는 필수 입력 항목 입니다."));
                return;
            }

            if (String.IsNullOrEmpty(tbFileNm.Text))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "파일시작명", "파일시작명은 필수 입력 항목 입니다."));
                return;
            }

            if (String.IsNullOrEmpty(tbSubFolderNm.Text))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "서브폴더", "서브폴더는 필수 입력 항목 입니다."));
                return;
            }


            string sql = null;
            // 1. 중복된 업로드 기간이 있는지 체크 (활성화되어 있고, 확장자/파일명이 동일한 스케쥴에서만 중복 체크)
            sql = String.Format(@"SELECT 
                      REALTIME_YN
                    , UPLOAD_TIME
                    , UPLOAD_FROM_DT
                    , UPLOAD_FROM_TIME
                    , UPLOAD_TO_DT
                    , UPLOAD_TO_TIME
                    , USE_YN
                FROM SCHEDULE_INFO 
                WHERE USE_YN = 'Y' AND FILE_EXT = '{0}' AND FILE_NM = '{1}'", tbFileExt.Text, tbFileNm.Text);

            // update일 경우
            if (!hiddenScheduleSeq.Text.Equals("0"))
                sql += " and SCHEDULE_SEQ != " + hiddenScheduleSeq.Text;

            DataTable dt = SQLiteHelper.SelectDataSet(sql).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("kskang(ScheduleMng:btnSave_Click)  {0}, {1}, {2}, {3}", dr["REALTIME_YN"].ToString(), dr["UPLOAD_TIME"].ToString(), dr["UPLOAD_FROM_DT"].ToString(), dr["UPLOAD_FROM_TIME"].ToString()));

                DateTime dtFrom = DateTime.Parse(dr["UPLOAD_FROM_DT"].ToString() + " " + dr["UPLOAD_FROM_TIME"].ToString());
                DateTime dtTo = DateTime.Parse(dr["UPLOAD_TO_DT"].ToString() + " " + dr["UPLOAD_TO_TIME"].ToString());

                DateTime dtFromNew = DateTime.Parse(dtpUploadFromDt.Value.ToShortDateString() + " " + dtpUploadFromTime.Value.Hour + ":" + dtpUploadFromTime.Value.Minute + ":00");
                DateTime dtToNew = DateTime.Parse(dtpUploadToDt.Value.ToShortDateString() + " " + dtpUploadToTime.Value.Hour + ":" + dtpUploadToTime.Value.Minute + ":00");

                if ((dtFrom <= dtFromNew && dtFromNew <= dtTo) || (dtFrom <= dtToNew && dtToNew <= dtTo))
                {
                    MessageBox.Show(Global.GetMultiLang("E-MSG-CHECK_UPLOAD_DT", "기존 스케쥴과 중복됩니다. 업로드기간을 확인해 주시기 바랍니다."));
                    return;
                }
            }

            // 2. insert일 경우
            #region Audit - insert/update
            var auditParams = new JObject();
            auditParams.Add("scheduleSeq", hiddenScheduleSeq.Text);
            auditParams.Add("fileExt", tbFileExt.Text);
            auditParams.Add("fileNm", tbFileNm.Text);
            auditParams.Add("realtimeYn", rbRealtime.Checked ? "Y" : "N");
            auditParams.Add("uploadTime", dtpUploadTime.Value.Hour + ":" + dtpUploadTime.Value.Minute + ":00");
            auditParams.Add("uploadFromDt", dtpUploadFromDt.Value.ToShortDateString());
            auditParams.Add("uploadFromTime", dtpUploadFromTime.Value.Hour + ":" + dtpUploadFromTime.Value.Minute + ":00");
            auditParams.Add("uploadToDt", dtpUploadToDt.Value.ToShortDateString());
            auditParams.Add("uploadToTime", dtpUploadToTime.Value.Hour + ":" + dtpUploadToTime.Value.Minute + ":00");
            auditParams.Add("useYn", rbActivate.Checked ? "Y" : "N");
            auditParams.Add("projCd", hiddenProjCd.Text);
            auditParams.Add("folderCd", hiddenFolderCd.Text);
            auditParams.Add("subFolderCd", hiddenSubFolderCd.Text);
            auditParams.Add("subFolderNm", tbSubFolderNm.Text);
            auditParams.Add("svrPk", svrPk);
            string auditUrl = "http://" + Global.svrUrl + "/api/sdms/insertScheduleInfo.do";
            JObject auditResult = RestApiRequest.CallSync(auditParams, auditUrl);
            #endregion

            if (hiddenScheduleSeq.Text.Equals("0"))
            {
                sql = string.Format(@"INSERT INTO SCHEDULE_INFO
                            (FILE_EXT, FILE_NM, REALTIME_YN, UPLOAD_TIME, UPLOAD_FROM_DT, UPLOAD_FROM_TIME, UPLOAD_TO_DT, UPLOAD_TO_TIME, USE_YN, PROJ_CD, FOLDER_CD, SUB_FOLDER_CD, SUB_FOLDER_NM, SVR_PK) 
                            VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', {13})"
                   , tbFileExt.Text
                   , tbFileNm.Text
                   , rbRealtime.Checked ? "Y" : "N"
                   , dtpUploadTime.Value.Hour + ":" + dtpUploadTime.Value.Minute + ":00"
                   , dtpUploadFromDt.Value.ToShortDateString()
                   , dtpUploadFromTime.Value.Hour + ":" + dtpUploadFromTime.Value.Minute + ":00"
                   , dtpUploadToDt.Value.ToShortDateString()
                   , dtpUploadToTime.Value.Hour + ":" + dtpUploadToTime.Value.Minute + ":00"
                   , rbActivate.Checked ? "Y" : "N"
                   , hiddenProjCd.Text
                   , hiddenFolderCd.Text
                   , hiddenSubFolderCd.Text
                   , tbSubFolderNm.Text
                   , auditResult["svrPk"]
                   );
            }
            // 2. update일 경우
            else
            {
                sql = string.Format(@"UPDATE SCHEDULE_INFO SET
                          FILE_EXT = '{0}'
                        , FILE_NM = '{1}'
                        , REALTIME_YN = '{2}'
                        , UPLOAD_TIME = '{3}'
                        , UPLOAD_FROM_DT = '{4}'
                        , UPLOAD_FROM_TIME = '{5}'
                        , UPLOAD_TO_DT = '{6}'
                        , UPLOAD_TO_TIME = '{7}'
                        , USE_YN = '{8}'
                        , PROJ_CD = '{9}'
                        , FOLDER_CD = '{10}'
                        , SUB_FOLDER_CD = '{11}'
                        , SUB_FOLDER_NM = '{12}'
                    WHERE SCHEDULE_SEQ = {13}"
                   , tbFileExt.Text
                   , tbFileNm.Text
                   , rbRealtime.Checked ? "Y" : "N"
                   , dtpUploadTime.Value.Hour + ":" + dtpUploadTime.Value.Minute + ":00"
                   , dtpUploadFromDt.Value.ToShortDateString()
                   , dtpUploadFromTime.Value.Hour + ":" + dtpUploadFromTime.Value.Minute + ":00"
                   , dtpUploadToDt.Value.ToShortDateString()
                   , dtpUploadToTime.Value.Hour + ":" + dtpUploadToTime.Value.Minute + ":00"
                   , rbActivate.Checked ? "Y" : "N"
                   , hiddenProjCd.Text
                   , hiddenFolderCd.Text
                   , hiddenSubFolderCd.Text
                   , tbSubFolderNm.Text
                   , hiddenScheduleSeq.Text
                   );
            }

            SQLiteHelper.SaveData(sql);

            // 스케쥴그리드 정보 불러오기
            MakeScheduleGrid();

            // 스케쥴정보 입력폼들 초기화
            ResetScheduleInfo();

            MessageBox.Show(Global.GetMultiLang("E-MSG-SAVE_OK", "정상적으로 저장 되었습니다."));
        }

        //삭제버튼 클릭시
        private void btnTest_Click(object sender, EventArgs e)
        {
            string sql = string.Format("DELETE FROM SCHEDULE_INFO WHERE SCHEDULE_SEQ = {0}", hiddenScheduleSeq.Text);
            SQLiteHelper.SaveData(sql);

            #region Audit - delete
            var auditParams = new JObject();
            auditParams.Add("scheduleSeq", hiddenScheduleSeq.Text);
            auditParams.Add("clientSeq", Global.clientSeq);
            auditParams.Add("action", "D");
            string auditUrl = "http://" + Global.svrUrl + "/api/sdms/insertScheduleInfo.do";
            RestApiRequest.CallAsync(auditParams, auditUrl);
            #endregion

            // 스케쥴그리드 정보 불러오기
            MakeScheduleGrid();

            // 스케쥴정보 입력폼들 초기화
            ResetScheduleInfo();

            MessageBox.Show(Global.GetMultiLang("E-MSG-DEL_OK", "정상적으로 삭제 되었습니다."));
        }

        // 서브폴더검색 버튼 클릭시
        private void btnSearchSubFolder_Click(object sender, EventArgs e)
        {
            SubFolderPop subFolderPop = new SubFolderPop("scheduleMngFrm");
            subFolderPop.ShowDialog(this);

            hiddenProjCd.Text = projCd;
            hiddenFolderCd.Text = folderCd;
            hiddenSubFolderCd.Text = subfolderCd;
            tbSubFolderNm.Text = subfolderNm;
        }
        #endregion

        #region 그리드 이벤트
        // 그리드 row 선택시
        private void dgvSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // 선택한 세부정보 뿌려주기
            int iRowIndex = dgvSchedule.CurrentRow.Index;


            // hidden값
            svrPk = dgvSchedule.Rows[iRowIndex].Cells["SVR_PK"].Value.ToString();

            hiddenScheduleSeq.Text = dgvSchedule.Rows[iRowIndex].Cells["SCHEDULE_SEQ"].Value.ToString();
            hiddenProjCd.Text = dgvSchedule.Rows[iRowIndex].Cells["PROJ_CD"].Value.ToString();
            hiddenFolderCd.Text = dgvSchedule.Rows[iRowIndex].Cells["FOLDER_CD"].Value.ToString();
            hiddenSubFolderCd.Text = dgvSchedule.Rows[iRowIndex].Cells["SUB_FOLDER_CD"].Value.ToString();

            tbFileExt.Text = dgvSchedule.Rows[iRowIndex].Cells["FILE_EXT"].Value.ToString();
            tbFileNm.Text = dgvSchedule.Rows[iRowIndex].Cells["FILE_NM"].Value.ToString();

            if (dgvSchedule.Rows[iRowIndex].Cells["REALTIME_YN"].Value.ToString().Equals("Y"))
                rbRealtime.Checked = true;
            else
            {
                rbOneAday.Checked = true;
                dtpUploadTime.Text = dgvSchedule.Rows[iRowIndex].Cells["UPLOAD_TIME"].Value.ToString();
            }

            dtpUploadFromDt.Text = dgvSchedule.Rows[iRowIndex].Cells["UPLOAD_FROM_DT"].Value.ToString();
            dtpUploadFromTime.Text = dgvSchedule.Rows[iRowIndex].Cells["UPLOAD_FROM_TIME"].Value.ToString();

            dtpUploadToDt.Text = dgvSchedule.Rows[iRowIndex].Cells["UPLOAD_TO_DT"].Value.ToString();
            dtpUploadToTime.Text = dgvSchedule.Rows[iRowIndex].Cells["UPLOAD_TO_TIME"].Value.ToString();

            if (dgvSchedule.Rows[iRowIndex].Cells["USE_YN"].Value.ToString().Equals("Y"))
                rbActivate.Checked = true;
            else
                rbDeactivate.Checked = true;

            // 서브폴더명
            tbSubFolderNm.Text = dgvSchedule.Rows[iRowIndex].Cells["SUB_FOLDER_NM"].Value.ToString();

            btnSave.Enabled = true;
            btnDelete.Enabled = true;
        }

        // 데이터 바인딩후 
        private void dgvSchedule_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // 한줄 선택 삭제
            dgvSchedule.ClearSelection();
        }

        // 그리드 row 색깔 변경
        private void dgvSchedule_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string USE_YN = dgvSchedule["USE_YN", e.RowIndex].Value.ToString();
            System.Diagnostics.Debug.WriteLine(string.Format("kskang: dgvSchedule_RowPostPaint USE_YN = {0}", USE_YN));

            // 비활성화된 디바이스 목록은 회색
            if (USE_YN.Equals("N"))
                dgvSchedule.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(224, 224, 224);
        }
        #endregion

        private void panTitle_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panTitle.ClientRectangle,
               Color.White, 0, ButtonBorderStyle.Solid, // left
               Color.DimGray, 0, ButtonBorderStyle.Solid, // top
               Color.DimGray, 0, ButtonBorderStyle.Solid, // right
               Color.White, 1, ButtonBorderStyle.Solid);// bottom
        }
    }
}
