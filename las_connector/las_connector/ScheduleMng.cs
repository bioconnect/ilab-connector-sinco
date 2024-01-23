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
using LSP.Common;
using Newtonsoft.Json.Linq;

namespace LASConnector
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

            // 장비리스트 셋팅
            MakeDevList();

            // 그리드 색 변경
            dgvSchedule.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 208, 237);
            dgvSchedule.DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 208, 237);
            dgvSchedule.DefaultCellStyle.SelectionForeColor = Color.Black;

            // 다국어적용
            label1.Text = Global.GetMultiLang("E-TXT-SCHEDULE", "스케쥴");
            label2.Text = Global.GetMultiLang("E-TXT-SCHEDULE_LIST", "스케쥴목록");
            label3.Text = Global.GetMultiLang("E-TXT-SCHEDULE_INFO", "스케쥴정보");

            label8.Text = Global.GetMultiLang("E-TXT-SCHEDULE_NM", "스케쥴명");
            label6.Text = Global.GetMultiLang("E-TXT-DEV_NAME", "장비명");
            label7.Text = Global.GetMultiLang("E-TXT-DEV_WARTCH_FOLDER", "장비감시폴더");
            label10.Text = Global.GetMultiLang("E-TXT-UPLOAD_TIME", "업로드시점");
            label9.Text = Global.GetMultiLang("E-TXT-UPLOAD_DT", "업로드기간");
            label4.Text = Global.GetMultiLang("E-TXT-ACTIVE_YN", "활성화여부");

            rbRealtime.Text = Global.GetMultiLang("E-TXT-REALTIME", "실시간");
            rbOneAday.Text = Global.GetMultiLang("E-TXT-ONETIME", "1회/1일");
            label11.Text = Global.GetMultiLang("E-TXT-START", "시작");
            label13.Text = Global.GetMultiLang("E-TXT-END", "종료");
            rbActivate.Text = Global.GetMultiLang("E-TXT-ACTIVE", "활성화");
            rbDeactivate.Text = Global.GetMultiLang("E-TXT-DEACTIVE", "비활성화");

            btnNew.Text = Global.GetMultiLang("E-TXT-ADD", "추가");
            btnSave.Text = Global.GetMultiLang("E-TXT-SAVE", "저장");
            btnDelete.Text = Global.GetMultiLang("E-TXT-DEL", "삭제");
        }

        #region method
        // 스케쥴그리드 정보 불러오기
        private void MakeScheduleGrid()
        {
            string sql = @"SELECT 
                      SCHEDULE_SEQ
                    , SCHEDULE_NM
                    , DEV_CD
                    , DEV_NM
                    , DEV_WATCH_FOLDER
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
                    , SVR_PK
                FROM SCHEDULE_INFO";
            DataTable dt = SQLiteHelper.SelectDataSet(sql).Tables[0];

            // 그리드 바인딩
            dgvSchedule.DataSource = null;
            dgvSchedule.DataSource = dt;

            // 불필요한 컬럼은 안보이도록 처리
            dgvSchedule.Columns["DEV_CD"].Visible = false;
            dgvSchedule.Columns["SCHEDULE_SEQ"].Visible = false;
            dgvSchedule.Columns["REALTIME_YN"].Visible = false;
            dgvSchedule.Columns["UPLOAD_TIME"].Visible = false;
            dgvSchedule.Columns["UPLOAD_FROM_DT"].Visible = false;
            dgvSchedule.Columns["UPLOAD_FROM_TIME"].Visible = false;
            dgvSchedule.Columns["UPLOAD_TO_DT"].Visible = false;
            dgvSchedule.Columns["UPLOAD_TO_TIME"].Visible = false;
            dgvSchedule.Columns["USE_YN"].Visible = false;
            dgvSchedule.Columns["SVR_PK"].Visible = false;

            // 저장, 삭제후 다시 바인딩시 헤더값이 초기화 되서 명시적으로 넣어줌.
            dgvSchedule.Columns["SCHEDULE_NM"].HeaderText = "스케쥴명";
            dgvSchedule.Columns["DEV_NM"].HeaderText = "장비명";
            dgvSchedule.Columns["DEV_WATCH_FOLDER"].HeaderText = "장비감시폴더";
            dgvSchedule.Columns["REALTIME"].HeaderText = "업로드시점";
            dgvSchedule.Columns["UPLOAD_FROM"].HeaderText = "업로드 시작";
            dgvSchedule.Columns["UPLOAD_TO"].HeaderText = "업로드 종료";
            dgvSchedule.Columns["USE"].HeaderText = "활성화 여부";

            // 가로폭
            dgvSchedule.Columns["SCHEDULE_NM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSchedule.Columns["DEV_NM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSchedule.Columns["DEV_WATCH_FOLDER"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSchedule.Columns["REALTIME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSchedule.Columns["UPLOAD_FROM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSchedule.Columns["UPLOAD_TO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSchedule.Columns["USE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        // 스케쥴정보 입력폼들 초기화
        private void ResetScheduleInfo()
        {
            tlpScheduleInfo.Enabled = true;

            svrPk = "0";
            hiddenScheduleSeq.Text = "0";
            tbScheduleNm.Text = string.Empty;
            cbDevInfo.Text = string.Empty;
            tbDevWatchFolder.Text = string.Empty;
            rbActivate.Checked = true;
            dtpUploadTime.ResetText();
            dtpUploadFromDt.ResetText();
            dtpUploadFromTime.ResetText();
            dtpUploadToDt.ResetText();
            dtpUploadToTime.ResetText();
            rbActivate.Checked = true;
        }

        // 장비리스트 셋팅
        private void MakeDevList()
        {
            // set req params
            var reqParams = new JObject();
            reqParams.Add("comCd", Global.comCd);
            reqParams.Add("plantCd", Global.plantCd);
            reqParams.Add("clientCd", Global.clientSeq);

            // call api
            string targetUrl = "http://" + Global.svrUrl + "/api/las/selectDeviceList.do";
            JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);

            // 콤보박스값 셋팅            
            foreach (JObject listVal in resultJson["data"])
            {
                cbDevInfo.Items.Add(listVal);
            }
            cbDevInfo.DisplayMember = "devNm";
            cbDevInfo.ValueMember = "devCd";
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

        // 신규버튼 클릭시
        private void btnNew_Click(object sender, EventArgs e)
        {
            // 스케쥴정보 입력폼들 초기화
            ResetScheduleInfo();

            tbScheduleNm.Focus();
        }

        // 저장버튼 클릭시
        private void btnSave_Click(object sender, EventArgs e)
        {
            // validation
            if (String.IsNullOrEmpty(tbScheduleNm.Text))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "스케쥴명", "스케쥴명은 필수 입력 항목 입니다."));
                return;
            }

            if (cbDevInfo.SelectedIndex < 0)
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "장비", "장비는 필수 입력 항목 입니다."));
                return;
            }

            if (String.IsNullOrEmpty(tbDevWatchFolder.Text))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-FIRST_WATCHFOLDER", "장비감시폴더를 먼저 설정하시기 바랍니다."));
                return;
            }

            string sql = null;
            string devCd = ((JObject)cbDevInfo.SelectedItem)["devCd"].ToString();
            string devNm = ((JObject)cbDevInfo.SelectedItem)["devNm"].ToString();
            string fileType = ((JObject)cbDevInfo.SelectedItem)["fileType"].ToString();
            // 1. 중복된 업로드 기간이 있는지 체크 (활성화되어 있고, 장비가 동일한 스케쥴에서만 중복 체크)
            sql = String.Format(@"SELECT 
                      REALTIME_YN
                    , UPLOAD_TIME
                    , UPLOAD_FROM_DT
                    , UPLOAD_FROM_TIME
                    , UPLOAD_TO_DT
                    , UPLOAD_TO_TIME
                    , USE_YN
                FROM SCHEDULE_INFO 
                WHERE USE_YN = 'Y' AND DEV_CD = '{0}'", devCd);

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
                    MessageBox.Show(Global.GetMultiLang("E-MSG-SCHEDULE_AGAGIN", "기존 스케쥴과 중복됩니다. 업로드기간을 확인해 주시기 바랍니다."), "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // 2. insert일 경우
            #region Audit - insert/update
            var auditParams = new JObject();
            auditParams.Add("scheduleSeq", hiddenScheduleSeq.Text);
            auditParams.Add("clientSeq", Global.clientSeq);
            auditParams.Add("devCd", devCd);
            auditParams.Add("devNm", devNm);
            auditParams.Add("fileType", fileType);
            auditParams.Add("devWatchFolder", tbDevWatchFolder.Text);
            auditParams.Add("realtimeYn", rbRealtime.Checked ? "Y" : "N");
            auditParams.Add("uploadTime", dtpUploadTime.Value.Hour + ":" + dtpUploadTime.Value.Minute + ":00");
            auditParams.Add("uploadFromDt", dtpUploadFromDt.Value.ToShortDateString());
            auditParams.Add("uploadFromTime", dtpUploadFromTime.Value.Hour + ":" + dtpUploadFromTime.Value.Minute + ":00");
            auditParams.Add("uploadToDt", dtpUploadToDt.Value.ToShortDateString());
            auditParams.Add("uploadToTime", dtpUploadToTime.Value.Hour + ":" + dtpUploadToTime.Value.Minute + ":00");
            auditParams.Add("useYn", rbActivate.Checked ? "Y" : "N");
            auditParams.Add("svrPk", svrPk);
            string auditUrl = "http://" + Global.svrUrl + "/api/las/insertScheduleInfo.do";
            JObject auditResult = RestApiRequest.CallSync(auditParams, auditUrl);
            #endregion

            if (hiddenScheduleSeq.Text.Equals("0"))
            {
                sql = string.Format(@"INSERT INTO SCHEDULE_INFO 
                            (SCHEDULE_NM, DEV_CD, DEV_NM, FILE_TYPE, DEV_WATCH_FOLDER, REALTIME_YN, UPLOAD_TIME, UPLOAD_FROM_DT, UPLOAD_FROM_TIME, UPLOAD_TO_DT, UPLOAD_TO_TIME, USE_YN, SVR_PK) 
                            VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')"
                   , tbScheduleNm.Text
                   , devCd
                   , devNm
                   , fileType
                   , tbDevWatchFolder.Text
                   , rbRealtime.Checked ? "Y" : "N"
                   , dtpUploadTime.Value.Hour + ":" + dtpUploadTime.Value.Minute + ":00"
                   , dtpUploadFromDt.Value.ToShortDateString()
                   , dtpUploadFromTime.Value.Hour + ":" + dtpUploadFromTime.Value.Minute + ":00"
                   , dtpUploadToDt.Value.ToShortDateString()
                   , dtpUploadToTime.Value.Hour + ":" + dtpUploadToTime.Value.Minute + ":00"
                   , rbActivate.Checked ? "Y" : "N"
                   , auditResult["svrPk"]
                   );
            }
            // 2. update일 경우
            else
            {
                sql = string.Format(@"UPDATE SCHEDULE_INFO SET
                          SCHEDULE_NM = '{0}'
                        , DEV_CD = '{1}'
                        , DEV_NM = '{2}'
                        , FILE_TYPE = '{3}'
                        , DEV_WATCH_FOLDER = '{4}'
                        , REALTIME_YN = '{5}'
                        , UPLOAD_TIME = '{6}'
                        , UPLOAD_FROM_DT = '{7}'
                        , UPLOAD_FROM_TIME = '{8}'
                        , UPLOAD_TO_DT = '{9}'
                        , UPLOAD_TO_TIME = '{10}'
                        , USE_YN = '{11}'
                    WHERE SCHEDULE_SEQ = {12}"
                   , tbScheduleNm.Text
                   , devCd
                   , devNm
                   , fileType
                   , tbDevWatchFolder.Text
                   , rbRealtime.Checked ? "Y" : "N"
                   , dtpUploadTime.Value.Hour + ":" + dtpUploadTime.Value.Minute + ":00"
                   , dtpUploadFromDt.Value.ToShortDateString()
                   , dtpUploadFromTime.Value.Hour + ":" + dtpUploadFromTime.Value.Minute + ":00"
                   , dtpUploadToDt.Value.ToShortDateString()
                   , dtpUploadToTime.Value.Hour + ":" + dtpUploadToTime.Value.Minute + ":00"
                   , rbActivate.Checked ? "Y" : "N"
                   , hiddenScheduleSeq.Text
                   );
            }

            SQLiteHelper.SaveData(sql);

            // 스케쥴그리드 정보 불러오기
            MakeScheduleGrid();

            // 스케쥴정보 입력폼들 초기화
            ResetScheduleInfo();

            MessageBox.Show(Global.GetMultiLang("E-MSG-SAVE_OK_RESTART", "정상적으로 저장 되었습니다.\n스케쥴 적용을 위해 프로그램을 재시작해 주시기 바랍니다."));
        }

        //삭제버튼 클릭시
        private void btnTest_Click(object sender, EventArgs e)
        {
            string sql = string.Format("DELETE FROM SCHEDULE_INFO WHERE SCHEDULE_SEQ = {0}", hiddenScheduleSeq.Text);
            SQLiteHelper.SaveData(sql);

            // 스케쥴그리드 정보 불러오기
            MakeScheduleGrid();

            // 스케쥴정보 입력폼들 초기화
            ResetScheduleInfo();

            MessageBox.Show(Global.GetMultiLang("E-MSG-DEL_OK", "정상적으로 삭제 되었습니다."));
        }
        #endregion

        #region 그리드 이벤트
        // 그리드 row 선택시
        private void dgvSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 스케쥴정보 입력폼들 초기화
            ResetScheduleInfo();

            // 선택한 세부정보 뿌려주기
            int iRowIndex = dgvSchedule.CurrentRow.Index;

            // svrpk
            svrPk = dgvSchedule.Rows[iRowIndex].Cells["SVR_PK"].Value.ToString();

            // 스케쥴seq
            hiddenScheduleSeq.Text = dgvSchedule.Rows[iRowIndex].Cells["SCHEDULE_SEQ"].Value.ToString();

            // 스케쥴명
            tbScheduleNm.Text = dgvSchedule.Rows[iRowIndex].Cells["SCHEDULE_NM"].Value.ToString();

            // 장비명
            cbDevInfo.Text = dgvSchedule.Rows[iRowIndex].Cells["DEV_NM"].Value.ToString();

            // 장비감시폴더
            tbDevWatchFolder.Text = dgvSchedule.Rows[iRowIndex].Cells["DEV_WATCH_FOLDER"].Value.ToString();

            // 실시간여부
            if (dgvSchedule.Rows[iRowIndex].Cells["REALTIME_YN"].Value.ToString().Equals("Y"))
                rbRealtime.Checked = true;
            else
            {
                rbOneAday.Checked = true;
                dtpUploadTime.Text = dgvSchedule.Rows[iRowIndex].Cells["UPLOAD_TIME"].Value.ToString();
            }

            // 업로드 기간
            dtpUploadFromDt.Text = dgvSchedule.Rows[iRowIndex].Cells["UPLOAD_FROM_DT"].Value.ToString();
            dtpUploadFromTime.Text = dgvSchedule.Rows[iRowIndex].Cells["UPLOAD_FROM_TIME"].Value.ToString();

            dtpUploadToDt.Text = dgvSchedule.Rows[iRowIndex].Cells["UPLOAD_TO_DT"].Value.ToString();
            dtpUploadToTime.Text = dgvSchedule.Rows[iRowIndex].Cells["UPLOAD_TO_TIME"].Value.ToString();

            // 사용여부
            if (dgvSchedule.Rows[iRowIndex].Cells["USE_YN"].Value.ToString().Equals("Y"))
                rbActivate.Checked = true;
            else
                rbDeactivate.Checked = true;

            // 버튼 상태
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
        }

        // 데이터 바인딩후 
        private void dgvSchedule_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // 한줄 선택 삭제
            dgvSchedule.ClearSelection();
        }

        // 장비 선택시
        private void cbDevInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(ScheduleMng) cbDevInfo_SelectedIndexChanged"));

            JObject jsonResult = (JObject)cbDevInfo.SelectedItem;

            tbDevWatchFolder.Text = jsonResult["devWatchFolder"].ToString();
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

        private void ScheduleMng_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panScheduleList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void subPan2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void subPan4_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

    }
}
