using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;

using LSP.Common;

namespace LASConnector
{
    public partial class ServerMng : Form
    {
        public string selSvrSeq;   // 그리드에서 선택된 row의 seq
        public string selSvrNm;   // 그리드에서 선택된 row의 서버명
        public string selSvrIp;   // 그리드에서 선택된 row의 IP:PORT


        public ServerMng()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(ServerMng) init!"));

            InitializeComponent();

            // select후 그리드 셋팅
            MakeDataGridView();

            // 그리드 색 변경
            dgvSever.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 208, 237);
            dgvSever.DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 208, 237);
            dgvSever.DefaultCellStyle.SelectionForeColor = Color.Black;

            // 다국어적용
            label3.Text = Global.GetMultiLang("E-TXT-SERVER_MNG", "서버관리");
            btnReg.Text = Global.GetMultiLang("E-TXT-REG", "등록");
            btnMod.Text = Global.GetMultiLang("E-TXT-MOD", "수정");
            btnDel.Text = Global.GetMultiLang("E-TXT-DEL", "삭제");
            btnDefault.Text = Global.GetMultiLang("E-TXT-DEFAULT", "기본설정");
        }

        #region method
        // 수정, 삭제, 기본값 버튼 활성화 비활성화 처리
        private void SetBtnEnableStatus(bool active)
        {
            btnMod.Enabled = active;
            btnDel.Enabled = active;
            btnDefault.Enabled = active;
        }

        // select후 그리드 셋팅
        private void MakeDataGridView()
        {
            string sql = "SELECT SVR_SEQ, SVR_NM, SVR_IP, DEFAULT_YN FROM SVR_INFO ORDER BY SVR_SEQ DESC";
            DataTable dt = SQLiteHelper.SelectDataSet(sql).Tables[0];

            // 그리드 바인딩
            dgvSever.DataSource = null;
            dgvSever.DataSource = dt;

            // 불필요한 컬럼은 안보이도록 처리
            dgvSever.Columns["SVR_SEQ"].Visible = false;
            dgvSever.Columns["DEFAULT_YN"].Visible = false;

            // 재바인딩시 헤더값이 초기화 되서 명시적으로 넣어줌.
            dgvSever.Columns["SVR_SEQ"].HeaderText = Global.GetMultiLang("E-TXT-NO", "순번");
            dgvSever.Columns["SVR_NM"].HeaderText = Global.GetMultiLang("E-TXT-SERVER_NM", "서버명");
            dgvSever.Columns["DEFAULT_YN"].HeaderText = Global.GetMultiLang("E-TXT-DEFAULT_YN", "기본값여부");

            dgvSever.Columns["SVR_SEQ"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSever.Columns["SVR_NM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSever.Columns["SVR_IP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSever.Columns["DEFAULT_YN"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        #endregion

        #region 버튼 이벤트
        // 등록 버튼
        private void btnReg_Click(object sender, EventArgs e)
        {
            ServerReg serverReg = new ServerReg(null, null, null);
            serverReg.ShowDialog();

            MakeDataGridView();
        }

        // 수정 버튼
        private void btnMod_Click(object sender, EventArgs e)
        {
            ServerReg serverReg = new ServerReg(selSvrSeq, selSvrNm, selSvrIp);
            serverReg.ShowDialog();

            MakeDataGridView();

            SetBtnEnableStatus(false);
        }

        // 삭제 버튼
        private void btnDel_Click(object sender, EventArgs e)
        {
            string sql = string.Format("DELETE FROM SVR_INFO WHERE SVR_SEQ = {0}", selSvrSeq);
            SQLiteHelper.SaveData(sql);
            MessageBox.Show(Global.GetMultiLang("E-MSG-DEL_OK", "정상적으로 삭제 되었습니다."));

            MakeDataGridView();

            SetBtnEnableStatus(false);
        }

        // 기본설정 버튼
        private void btnDefault_Click(object sender, EventArgs e)
        {
            // 모두 N으로 변경 후
            string sql = string.Format("UPDATE SVR_INFO SET DEFAULT_YN = 'N'");
            SQLiteHelper.SaveData(sql);

            sql = string.Format("UPDATE SVR_INFO SET DEFAULT_YN = 'Y' WHERE SVR_SEQ = {0}", selSvrSeq);
            SQLiteHelper.SaveData(sql);

            MessageBox.Show("선택한 서버가 기본설정 되었습니다.");
            MakeDataGridView();

            SetBtnEnableStatus(false);
        }
        #endregion

        #region 그리드 이벤트
        // 그리드 클릭시
        private void dgvSever_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRowIndex = dgvSever.CurrentRow.Index;
            selSvrSeq = dgvSever.Rows[iRowIndex].Cells["SVR_SEQ"].Value.ToString();
            selSvrNm = dgvSever.Rows[iRowIndex].Cells["SVR_NM"].Value.ToString();
            selSvrIp = dgvSever.Rows[iRowIndex].Cells["SVR_IP"].Value.ToString();

            SetBtnEnableStatus(true);
        }

        // 데이터 바인딩 후
        private void dgvSever_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(string.Format("kskang(ServerMng) dgvSever_DataBindingComplete"));

            // 한 셀 선택 지우기
            dgvSever.ClearSelection();
        }

        // 행 색깔 변경
        private void dgvSever_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strDefaultYn = dgvSever["DEFAULT_YN", e.RowIndex].Value.ToString();
            //System.Diagnostics.Debug.WriteLine(string.Format("kskang: dgvSever_RowPostPaint default_yn = {0}", strDefaultYn));

            if (strDefaultYn.Equals("Y"))
                dgvSever.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 204);
        }

        // 두번 클릭시 - 부모창에 해당값 전달하기
        private void dgvSever_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Login loginForm = (Login)this.Owner.ActiveControl;

            int iRowIndex = dgvSever.CurrentRow.Index;
            loginForm.svrNm = dgvSever.Rows[iRowIndex].Cells["SVR_NM"].Value.ToString();
            loginForm.svrIp = dgvSever.Rows[iRowIndex].Cells["SVR_IP"].Value.ToString();

            this.DialogResult = DialogResult.OK;

            this.Close();
        }
        #endregion

    }
}
