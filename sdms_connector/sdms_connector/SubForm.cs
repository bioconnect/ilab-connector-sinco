using LSP.Common;
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
    public partial class SubForm : Form
    {
        public delegate void FrmSendDataHandler(Object obj);
        public event FrmSendDataHandler FrmSendEvent;

        public SubForm(string activateFrm)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(SubForm) init!"));
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(SubForm) activateFrm = {0}", activateFrm));

            InitializeComponent();

            if (activateFrm.Equals("dataHisotryFrm"))
            {
                ViewDataHistoryFrm();
            }
            else if (activateFrm.Equals("ftpSettingFrm"))
            {
                ViewFtpSettingFrm();
            }

            // 클라이언트선택이 안되었거나, 감시여부가 수동이면 스케쥴버튼 비활성화
            if (String.IsNullOrEmpty(Global.clientSeq) || Global.clientSeq.Equals("0") || Global.folderAutoYn.Equals("N"))
                btnSchedule.Enabled = false;

            // 사용자 정보 출력
            lblPrivateInfo.Text = Global.deptNm + " " + Global.teamNm + " " + Global.userNm;

            // 다국어적용
            btnDataHistory.Text = Global.GetMultiLang("E-TXT-DATA_SEND_HISTORY", "데이터 전송 이력");
            btnClient.Text = Global.GetMultiLang("E-TXT-CLIENT", "클라이언트");
            btnSchedule.Text = Global.GetMultiLang("E-TXT-SCHEDULE", "스케쥴");
        }

        #region method
        // 클라이언트폼에서 호출하는 이벤트 처리
        public void ProcClientFrmEvent(Object obj)
        {
            // 클라이언트가 설정 되고
            if (!String.IsNullOrEmpty(Global.clientSeq))
            {
                // 감시여부가 자동이면 스케쥴버튼 활성화
                if (obj.Equals("auto"))
                {
                    Global.folderAutoYn = "Y";
                    btnSchedule.Enabled = true;
                    this.FrmSendEvent("auto");
                }
                else
                {
                    Global.folderAutoYn = "N";
                    btnSchedule.Enabled = false;
                    this.FrmSendEvent("manual");
                }
            }
        }
        #endregion

        #region 폼 활성화 method
        // view 데이터이력폼 
        public void ViewDataHistoryFrm()
        {
            DataHistory dataHistoryFrm = new DataHistory();
            dataHistoryFrm.TopLevel = false;
            dataHistoryFrm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            dataHistoryFrm.Dock = DockStyle.Fill;

            panBottomDetail.Controls.Clear();
            panBottomDetail.Controls.Add(dataHistoryFrm);
            dataHistoryFrm.Parent = this.panBottomDetail;

            dataHistoryFrm.Show();
        }

        // view ftp셋팅폼
        public void ViewFtpSettingFrm()
        {
            FtpSetting ftpSettingFrm = new FtpSetting();
            ftpSettingFrm.TopLevel = false;
            ftpSettingFrm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            ftpSettingFrm.Dock = DockStyle.Fill;

            panBottomDetail.Controls.Clear();
            panBottomDetail.Controls.Add(ftpSettingFrm);
            ftpSettingFrm.Parent = this.panBottomDetail;

            ftpSettingFrm.Show();
        }

        // view 클라이언트폼
        public void ViewClientMngFrm()
        {
            ClientMng clientMngFrm = new ClientMng();
            clientMngFrm.FrmSendEvent += new ClientMng.FrmSendDataHandler(ProcClientFrmEvent);
            clientMngFrm.TopLevel = false;
            clientMngFrm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            clientMngFrm.Dock = DockStyle.Fill;

            panBottomDetail.Controls.Clear();
            panBottomDetail.Controls.Add(clientMngFrm);
            clientMngFrm.Parent = this.panBottomDetail;

            clientMngFrm.Show();
        }

        // view 스케쥴폼
        public void ViewScheduleMngFrm()
        {
            ScheduleMng scheduleMngFrm = new ScheduleMng();
            scheduleMngFrm.TopLevel = false;
            scheduleMngFrm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            scheduleMngFrm.Dock = DockStyle.Fill;

            panBottomDetail.Controls.Clear();
            panBottomDetail.Controls.Add(scheduleMngFrm);
            scheduleMngFrm.Parent = this.panBottomDetail;

            scheduleMngFrm.Show();
        }
        #endregion

        #region 메뉴버튼 이벤트
        // 데이터전송이력폼 활성화
        private void btnDataHistory_Click(object sender, EventArgs e)
        {
            ViewDataHistoryFrm();
        }

        // ftp셋팅폼 활성화
        private void btnFtpSetting_Click(object sender, EventArgs e)
        {
            ViewFtpSettingFrm();
        }

        // 클라이언트폼 활성화
        private void btnClient_Click(object sender, EventArgs e)
        {
            ViewClientMngFrm();
        }

        // 스케쥴폼 활성화
        private void btnSchedule_Click(object sender, EventArgs e)
        {
            ViewScheduleMngFrm();
        }
        #endregion

    }
}
