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
using LSP.Common;

namespace LASConnector
{  
    public partial class ClientMng : Form
    {
        public delegate void FrmSendDataHandler(Object obj);
        public event FrmSendDataHandler FrmSendEvent;

        private string clientCd;
        private string clientID;
        private string svrPk;


        public ClientMng()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(ClientMng) init!"));
            InitializeComponent();

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
            label1.Text = Global.GetMultiLang("E-TXT-CLIENT", "클라이언트");
            label4.Text = Global.GetMultiLang("E-TXT-CLIENT_ID", "클라이언트ID");
            label6.Text = Global.GetMultiLang("E-TXT-CLIENT_NAME", "클라이언트명");
            label5.Text = Global.GetMultiLang("E-TXT-REG_DT", "등록일");
            lblClientList.Text = Global.GetMultiLang("E-TXT-CLIENT_LIST", "클라이언트 목록");
            btnSearch.Text = Global.GetMultiLang("E-TXT-SEARCH", "조회");
            btnSave.Text = Global.GetMultiLang("E-TXT-SAVE", "저장");
        }

        #region method
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
            string targetUrl = "http://" + Global.svrUrl + "/api/las/selectClientLAS.do";
            JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);

            if (resultJson["data"].Count() != 0)
            {
                // 그리드 바인딩
                dgvClient.DataSource = null;
                dgvClient.DataSource = resultJson["data"];

                // 불필요한 컬럼은 안보이도록 처리
                dgvClient.Columns["clientCd"].Visible = false;
                dgvClient.Columns["clientConnYn"].Visible = false;
                dgvClient.Columns["useYn"].Visible = false;

                // 재 바인딩시 헤더값이 초기화 되서 명시적으로 넣어줌.
                dgvClient.Columns["clientId"].HeaderText = Global.GetMultiLang("E-TXT-CLIENT_ID", "클라이언트ID");
                dgvClient.Columns["clientNm"].HeaderText = Global.GetMultiLang("E-TXT-CLIENT_NAME", "클라이언트명");
                dgvClient.Columns["modDt"].HeaderText = Global.GetMultiLang("E-TXT-REGDT", "등록일시");
                dgvClient.Columns["usePurpo"].HeaderText = Global.GetMultiLang("E-TXT-PURPOSE", "용도");

                dgvClient.Columns["clientId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvClient.Columns["clientNm"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvClient.Columns["modDt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvClient.Columns["usePurpo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvClient.ClearSelection();
            }
            else
            {
                dgvClient.DataSource = null;
                dgvClient.Rows.Clear();
            }
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
            this.Cursor = Cursors.WaitCursor;

            SelectClientList();

            this.Cursor = Cursors.Default;
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
            DialogResult dr = MessageBox.Show(Global.GetMultiLang("E-MSG-SCHEDULE_DELETE", "클라이언트 변경시 기존 스케쥴은 삭제됩니다.\n계속하시겠습니까?"), "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                if (Global.clientSeq != clientCd)
                {
                    // 1. 서버로 전송
                    // set req params
                    var reqParams = new JObject();
                    reqParams.Add("clientCdBefore", Global.clientSeq);
                    reqParams.Add("clientCdAfter", clientCd);
                    reqParams.Add("clientConnYn", "Y");
                    reqParams.Add("comCd", Global.comCd);
                    reqParams.Add("plantCd", Global.plantCd);

                    // call api
                    string targetUrl = "http://" + Global.svrUrl + "/api/las/updateClientConnLAS.do";
                    JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);
                }
                // 2. local update
                #region Audit - insert/update
                string auditSql = string.Format("SELECT SVR_PK FROM BASIC_INFO");
                DataTable dt = SQLiteHelper.SelectDataSet(auditSql).Tables[0];
                svrPk = dt.Rows[0]["SVR_PK"].ToString();
                if (string.IsNullOrEmpty(svrPk))
                    svrPk = "0";

                var auditParams = new JObject();
                auditParams.Add("clientSeq", clientCd);
                auditParams.Add("clientId", clientCd);
                auditParams.Add("svrPk", svrPk);
                string auditUrl = "http://" + Global.svrUrl + "/api/las/insertBasicInfo.do";
                JObject auditResult = RestApiRequest.CallSync(auditParams, auditUrl);

                svrPk = auditResult["svrPk"].ToString();
                #endregion

                string sql = string.Format("UPDATE BASIC_INFO SET CLIENT_SEQ = '{0}', CLIENT_ID = '{1}', SVR_PK = '{2}'"
                    , clientCd
                    , clientID
                    , svrPk
                );
                SQLiteHelper.SaveData(sql);

                // 3. local 스케쥴정보 삭제
                sql = string.Format("DELETE FROM SCHEDULE_INFO");
                SQLiteHelper.SaveData(sql);

                // 4. 서브폼으로 이벤트 발생
                Global.clientSeq = clientCd;
                this.FrmSendEvent(null);

                MessageBox.Show(Global.GetMultiLang("E-MSG-SAVE_OK", "정상적으로 저장 되었습니다."));

                SelectClientList();
            }
        }
        #endregion

        #region 그리드 이벤트
        // 그리드 row 선택시
        private void dgvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string clientConnYn = dgvClient["clientConnYn", e.RowIndex].Value.ToString();

                // 미연결 클라이언트일 경우
                if (clientConnYn.Equals("N"))
                {
                    clientCd = dgvClient["clientCd", e.RowIndex].Value.ToString();
                    clientID = dgvClient["clientId", e.RowIndex].Value.ToString();
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
            }
        }

        // 그리드 row 색깔 변경
        private void dgvClient_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string clientCd = dgvClient["clientCd", e.RowIndex].Value.ToString();
            string clientConnYn = dgvClient["clientConnYn", e.RowIndex].Value.ToString();
            //System.Diagnostics.Debug.WriteLine(string.Format("kskang: dgvClient_RowPostPaint clientCd, clientConnYn = {0} {1}", clientCd, clientConnYn));

            // 본 디바이스와 연결된 클라이언트 목록은 초록색
            if (clientCd.Equals(Global.clientSeq) && clientConnYn.Equals("Y"))
                dgvClient.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(47, 157, 39);

            // 이미 다른 디바이스와 연결된 클라이언트 목록은 회색
            if (!clientCd.Equals(Global.clientSeq) && clientConnYn.Equals("Y"))
                dgvClient.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(111, 111, 111);
        }

        private void panSearch_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
