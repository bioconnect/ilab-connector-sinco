using LASConnector;
using LSP.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sdms_connector
{
    public partial class Rs232Setting : Form
    {
        private JObject data;

        public Rs232Setting(JObject data)
        {
            InitializeComponent();

            // 시리얼통신 환경설정 정보 초기화
            initSerialConf();


            // 서버에서 가져온 정보 셋팅
            this.data = data;

            if (data["serialPort"] != null)
            {
                stopBit.SelectedItem = data["stopBit"].ToString();
                serialPort.SelectedItem = data["serialPort"].ToString();
                readTime.Text = data["readTime"].ToString();
                readMode.SelectedItem = data["readMode"].ToString();
                parityBit.SelectedItem = data["parityBit"].ToString();
                dataBit.SelectedItem = data["dataBit"].ToString();
                baudRate.SelectedItem = data["baudRate"].ToString();
                beginChar.Text = data["beginChar"].ToString();
                endChar.Text = data["endChar"].ToString();
            }

            // 다국어적용
            label3.Text = Global.GetMultiLang("E-TXT-PROTOCOL_SET", "프로토콜 설정");
            label1.Text = Global.GetMultiLang("E-TXT-PROTOCOL", "통신프로토콜");
            btnSave.Text = Global.GetMultiLang("E-TXT-SAVE", "저장");
            btnCheck.Text = Global.GetMultiLang("E-TXT-CONN_CHECK", "연결확인");
        }

        // 시리얼통신 환경설정 정보 초기화
        private void initSerialConf()
        {
            serialPort.DataSource = SerialPort.GetPortNames();

        }

        // 저장버튼 클릭시
        private void btnSave_Click(object sender, EventArgs e)
        {
            // validation
            if (serialPort.SelectedItem == null)
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "시리얼포트", "Serial Port는 필수 입력 항목 입니다."));
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

            reqParams.Add("stopBit", stopBit.Text);
            reqParams.Add("serialPort", serialPort.Text);
            reqParams.Add("readTime", readTime.Text);
            reqParams.Add("readMode", readMode.Text);
            reqParams.Add("parityBit", parityBit.Text);
            reqParams.Add("dataBit", dataBit.Text);
            reqParams.Add("baudRate", baudRate.Text);
            reqParams.Add("beginChar", beginChar.Text);
            reqParams.Add("endChar", endChar.Text);

            // call api
            string targetUrl = "http://" + Global.svrUrl + "/api/las/insertPtcInfo.do";
            JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);

            MessageBox.Show(Global.GetMultiLang("E-MSG-SAVE_OK", "정상적으로 저장 되었습니다."));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // 시리얼 통신 연결 여부 확인
        private void btnCheck_Click(object sender, EventArgs e)
        {
            SerialPort sp = null;
            try
            {
                sp = new SerialPort(serialPort.Text, Convert.ToInt32(baudRate.Text), Parity.None, Convert.ToInt32(dataBit.Text), StopBits.One);
                sp.Open();

                if (sp.IsOpen)
                {
                    MessageBox.Show(Global.GetMultiLang("E-MSG-PROGRAM_RESTRT", "정상적으로 연결가능합니다.\n장비연결을 위해 프로그램을 재시작해 주시기 바랍니다."), "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sp.Close();
                }
                else
                {
                    MessageBox.Show(Global.GetMultiLang("E-MSG-CONN_FAIL", "연결에 실패했습니다. 설정을 확인해 주시기 바랍니다."), "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
