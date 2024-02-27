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
    public partial class ClientMng : Form
    {
        public delegate void FrmSendDataHandler(Object obj);
        public event FrmSendDataHandler FrmSendEvent;

        private string clientSeq;
        private string svrPk;

        public ClientMng()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(ClientMng) init!"));
            InitializeComponent();

            // 기존 저장된 정보 불러오기
            SetBasicInfo();

            // 조회 버튼 가운데 정렬
            SetPositionSearchBtn();

            // 검색날짜 초기 셋팅
            DateTime nowDt = DateTime.Now;
            dtpSearchFrom.Value = nowDt.AddMonths(-1);

            // 그리드 색 변경
            dgvClient.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 208, 237);
            dgvClient.DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 208, 237);
            dgvClient.DefaultCellStyle.SelectionForeColor = Color.Black;

            // 다국어적용
            btnSearch.Text = Global.GetMultiLang("E-TXT-SEARCH", "조회");
            btnSave.Text = Global.GetMultiLang("E-TXT-SAVE", "저장");

            label1.Text = Global.GetMultiLang("E-TXT-CLIENT", "클라이언트");
            label4.Text = Global.GetMultiLang("E-TXT-CLIENT_ID", "클라이언트ID");
            label6.Text = Global.GetMultiLang("E-TXT-CLIENT_NM", "클라이언트명");
            label5.Text = Global.GetMultiLang("E-TXT-REG_DT", "등록일");
            lblClientList.Text = Global.GetMultiLang("E-TXT-CLIENT_LIST", "클라이언트 목록");
            lblClientInfo.Text = Global.GetMultiLang("E-TXT-CLIENT_INFO", "클라이언트 정보");
            label8.Text = Global.GetMultiLang("E-TXT-CLIENT_ID", "클라이언트ID");
            label10.Text = Global.GetMultiLang("E-TXT-WARCHFOLDER", "감시폴더");
            label9.Text = Global.GetMultiLang("E-TXT-AUTO_MANUAL", "자동/수동");
            rbAuto.Text = Global.GetMultiLang("E-TXT-AUTO", "자동");
            rbManual.Text = Global.GetMultiLang("E-TXT-MANUAL", "수동");
        }

        #region method
        // 기존 저장된 정보 불러오기
        private void SetBasicInfo()
        {
            string sql = "SELECT CLIENT_SEQ, CLIENT_ID, CLIENT_WATCH_FOLDER, FOLDER_AUTO_YN, SVR_PK FROM BASIC_INFO";
            DataTable dt = SQLiteHelper.SelectDataSet(sql).Tables[0];

            if (!string.IsNullOrEmpty(dt.Rows[0]["CLIENT_SEQ"].ToString()))
            {
                clientSeq = dt.Rows[0]["CLIENT_SEQ"].ToString();
                tbCliendID.Text = dt.Rows[0]["CLIENT_ID"].ToString();
                tbClientFolder.Text = dt.Rows[0]["CLIENT_WATCH_FOLDER"].ToString();
                svrPk = dt.Rows[0]["SVR_PK"].ToString();

                if (dt.Rows[0]["FOLDER_AUTO_YN"].ToString().Equals("Y"))
                    rbAuto.Checked = true;
                else if (dt.Rows[0]["FOLDER_AUTO_YN"].ToString().Equals("N"))
                    rbManual.Checked = true;

                btnSave.Enabled = true;
            }
        }

        // 클라이언트 목록 조회 후 그리드 셋팅
        private void SelectClientList()
        {
            // set req params
            var reqParams = new JObject();
            reqParams.Add("comCd", Global.comCd);
            reqParams.Add("plantCd", Global.plantCd);
            reqParams.Add("userId", Global.userPk);
            reqParams.Add("clientId", tbSearchClientID.Text);
            reqParams.Add("clientNm", tbSearchClientNm.Text);
            reqParams.Add("fromRegDt", dtpSearchFrom.Value.ToShortDateString());
            reqParams.Add("toRegDt", dtpSearchTo.Value.ToShortDateString());

            // call api
            string targetUrl = "http://" + Global.svrUrl + "/api/sdms/selectClientSDMS.do";
            JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);


            dgvClient.DataSource = null;
            if (resultJson["data"].Count() > 0)
            {
                // 그리드 바인딩
                dgvClient.DataSource = resultJson["data"];

                // 불필요한 컬럼은 안보이도록 처리
                dgvClient.Columns["clientSeq"].Visible = false;
                dgvClient.Columns["useYn"].Visible = false;
                dgvClient.Columns["clientConnYn"].Visible = false;
                dgvClient.Columns["regId"].Visible = false;
                dgvClient.Columns["modDt"].Visible = false;
                dgvClient.Columns["modId"].Visible = false;

                // 재 바인딩시 헤더값이 초기화 되서 명시적으로 넣어줌.
                dgvClient.Columns["clientId"].HeaderText = Global.GetMultiLang("E-TXT-CLIENT_ID", "클라이언트ID");
                dgvClient.Columns["clientNm"].HeaderText = Global.GetMultiLang("E-TXT-CLIENT_NAME", "클라이언트명");
                dgvClient.Columns["regDt"].HeaderText = Global.GetMultiLang("E-TXT-REG_DT", "등록일시");
                dgvClient.Columns["usePurpo"].HeaderText = Global.GetMultiLang("E-TXT-PURPOSE", "용도");

                dgvClient.Columns["clientId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvClient.Columns["clientNm"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvClient.Columns["regDt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvClient.Columns["usePurpo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvClient.RowHeadersWidth = 20;
            }

            dgvClient.ClearSelection();
        }

        // 조회 버튼 가운데 정렬
        private void SetPositionSearchBtn()
        {
            btnSearch.Left = (this.ClientSize.Width - btnSearch.Width) / 2;
        }
        #endregion

        #region  이벤트
        // 조회버튼 클릭시
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SelectClientList();
        }

        // 폼 크기 변경시
        private void ClientMng_Resize(object sender, EventArgs e)
        {
            // 조회 버튼 가운데 정렬
            SetPositionSearchBtn();
        }

        // 저장하기
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. validation
            if (String.IsNullOrEmpty(tbCliendID.Text))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "클라이언트ID", "클라이언트ID는 필수 입력 항목 입니다."));
                return;
            }

            if (String.IsNullOrEmpty(tbClientFolder.Text))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "감시폴더", "감시폴더는 필수 입력 항목 입니다."));
                return;
            }

            // 2. update
            #region Audit - insert/update
            var auditParams = new JObject();
            auditParams.Add("clientSeq", clientSeq);
            auditParams.Add("clientId", tbCliendID.Text);
            auditParams.Add("clientWatchFolder", tbClientFolder.Text);
            auditParams.Add("folderAutoYn", rbAuto.Checked ? "Y" : "N");
            auditParams.Add("svrPk", svrPk);
            string auditUrl = "http://" + Global.svrUrl + "/api/sdms/insertBasicInfo.do";
            JObject auditResult = RestApiRequest.CallSync(auditParams, auditUrl);

            svrPk = auditResult["svrPk"].ToString();
            #endregion

            string sql = string.Format("UPDATE BASIC_INFO SET CLIENT_SEQ = {0}, CLIENT_ID = '{1}', CLIENT_WATCH_FOLDER = '{2}', FOLDER_AUTO_YN = '{3}', SVR_PK = '{4}'"
                , clientSeq
                , tbCliendID.Text
                , tbClientFolder.Text
                , rbAuto.Checked ? "Y" : "N"
                , auditResult["svrPk"]);
            SQLiteHelper.SaveData(sql);

            SignForm SF = new SignForm();
            SF.ShowDialog();

            // 3. 서버로 전송

            if (Global.clientSeq != clientSeq)
            {
                // set req params
                var reqParams = new JObject();
                reqParams.Add("clientSeqBefore", Global.clientSeq);
                reqParams.Add("clientSeqAfter", clientSeq);
                reqParams.Add("clientConnYn", "Y");
                reqParams.Add("comCd", Global.comCd);
                reqParams.Add("plantCd", Global.plantCd);
                // call api
                string targetUrl = "http://" + Global.svrUrl + "/api/sdms/updateClientConnSDMS.do";
                JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);
            }

            // 서브폼으로 이벤트 발생
            Global.clientSeq = clientSeq;
            Global.clientID = tbCliendID.Text;
            Global.clientWatchFolder = tbClientFolder.Text;

            this.FrmSendEvent(rbAuto.Checked ? "auto" : "manual");

            MessageBox.Show(Global.GetMultiLang("E-MSG-SAVE_OK", "정상적으로 저장 되었습니다."));

            SelectClientList();
        }

        // 폴더찾아보기 버튼 클릭시
        private void btnSearchFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();

            string selPath = dialog.SelectedPath;
            tbClientFolder.Text = selPath;
        }
        #endregion

        #region 그리드 이벤트
        // 그리드 row 선택시
        private void dgvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string clientConnYn = dgvClient["clientConnYn", e.RowIndex].Value.ToString();
            clientSeq = dgvClient["clientSeq", e.RowIndex].Value.ToString();

            // 미연결 클라이언트일 경우
            if (clientConnYn.Equals("N"))
            {
                clientSeq = dgvClient["clientSeq", e.RowIndex].Value.ToString();
                tbCliendID.Text = dgvClient["clientId", e.RowIndex].Value.ToString();

                tbCliendID.Enabled = true;
                rbAuto.Enabled = true;
                rbManual.Enabled = true;

                btnSearchFolder.Enabled = true;
                btnSave.Enabled = true;
            }
            // 다른 디바이스와 연결된 경우
            else if (!clientSeq.Equals(Global.clientSeq) && clientConnYn.Equals("Y"))
            {
                tbCliendID.Text = "";
                tbClientFolder.Text = "";

                tbCliendID.Enabled = false;
                rbAuto.Enabled = false;
                rbManual.Enabled = false;

                btnSearchFolder.Enabled = false;
                btnSave.Enabled = false;
            }
            // 본 디바이스와 연결된 경우
            else if (clientSeq.Equals(Global.clientSeq) && clientConnYn.Equals("Y"))
            {
                // 기존 저장된 정보 불러오기
                SetBasicInfo();

                tbCliendID.Enabled = true;
                rbAuto.Enabled = true;
                rbManual.Enabled = true;

                btnSearchFolder.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        // 그리드 row 색깔 변경
        private void dgvClient_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string clientSeq = dgvClient["clientSeq", e.RowIndex].Value.ToString();
            string clientConnYn = dgvClient["clientConnYn", e.RowIndex].Value.ToString();

            // 본 디바이스와 연결된 클라이언트 목록은 노란색
            if (clientSeq.Equals(Global.clientSeq) && clientConnYn.Equals("Y"))
                // dgvClient.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 204);
                dgvClient.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(47, 157, 39);


            // 이미 다른 디바이스와 연결된 클라이언트 목록은 회색
            if (!clientSeq.Equals(Global.clientSeq) && clientConnYn.Equals("Y"))
                //dgvClient.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(224, 224, 224);
                dgvClient.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(111, 111, 111);

        }
        private void panSearch_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panSearch.ClientRectangle,
               Color.White, 0, ButtonBorderStyle.Solid, // left
               Color.DimGray, 1, ButtonBorderStyle.Solid, // top
               Color.DimGray, 0, ButtonBorderStyle.Solid, // right
               Color.White, 1, ButtonBorderStyle.Solid);// bottom
        }

        private void ClientMng_Load(object sender, EventArgs e)
        {

        }

        private void lblClientList_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        #endregion

        private void tblBody_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblClientList_Click_1(object sender, EventArgs e)
        {

        }

        private void rbAuto_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
