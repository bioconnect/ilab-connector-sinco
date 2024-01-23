using LSP.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sdms_connector
{
    public partial class TcpSetting : Form
    {
        private JObject data;

        public TcpSetting(JObject data)
        {
            InitializeComponent();

            this.data = data;

            if (data["ipAddr"] != null)
                tbIpAddr.Text = data["ipAddr"].ToString();

            if (data["subMask"] != null)
                tbSubMask.Text = data["subMask"].ToString();

            if (data["gateway"] != null)
                tbGateway.Text = data["gateway"].ToString();

            // 다국어적용
            label3.Text = Global.GetMultiLang("E-TXT-PROTOROL_SET", "프로토콜 설정");
            label1.Text = Global.GetMultiLang("E-TXT-PROTOCOL", "통신프로토콜");
            label5.Text = Global.GetMultiLang("E-TXT-SUBNET_MASK", "서브넷 마스크");
            label6.Text = Global.GetMultiLang("E-TXT-DEFAULT_GATEWAY", "기본 게이트웨이");
            btnSave.Text = Global.GetMultiLang("E-TXT-SAVE", "저장");
        }

        // 저장버튼 클릭시
        private void btnSave_Click(object sender, EventArgs e)
        {
            // validation
            IPAddress outIP = null;
            if (String.IsNullOrEmpty(tbIpAddr.Text))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "IP Address", "IP Address는 필수 입력 항목 입니다."));
                return;
            }
            if (String.IsNullOrEmpty(tbIpAddr.Text))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "서브넷 마스크", "서브넷 마스크는 필수 입력 항목 입니다."));
                return;
            }
            if (String.IsNullOrEmpty(tbIpAddr.Text))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "게이트웨이", "게이트웨이는 필수 입력 항목 입니다."));
                return;
            }

            if (!IPAddress.TryParse(tbIpAddr.Text, out outIP))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_WRONG", "IP Address", "IP Address가 올바르지 않습니다."));
                return;
            }
            if (!IPAddress.TryParse(tbSubMask.Text, out outIP))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_WRONG", "서브넷 마스크", "서브넷 마스크가 올바르지 않습니다."));
                return;
            }
            if (!IPAddress.TryParse(tbGateway.Text, out outIP))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_WRONG", "게이트웨이", "게이트웨이가 올바르지 않습니다."));
                return;
            }


            // set req params
            var reqParams = new JObject();
            reqParams.Add("comCd", data["comCd"].ToString());
            reqParams.Add("plantCd", data["plantCd"].ToString());
            reqParams.Add("clientCd", data["clientCd"].ToString());
            reqParams.Add("devCd", data["devCd"].ToString());
            reqParams.Add("ptcType", data["ptcType"].ToString());

            if (data["ptcCd"] != null)
                reqParams.Add("ptcCd", data["ptcCd"].ToString());

            reqParams.Add("ipAddr", tbIpAddr.Text);
            reqParams.Add("subMask", tbSubMask.Text);
            reqParams.Add("gateway", tbGateway.Text);

            // call api
            string targetUrl = "http://" + Global.svrUrl + "/api/las/insertPtcInfo.do";
            JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);

            MessageBox.Show(Global.GetMultiLang("E-MSG-SAVE_OK", "정상적으로 저장 되었습니다."));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
