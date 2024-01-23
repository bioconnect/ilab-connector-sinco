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
using sdms_connector;
using System.IO.Ports;

namespace LASConnector
{
    public partial class DeviceMng : Form
    {
        public DeviceMng()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(DeviceMng) init!"));
            InitializeComponent();

            // 장비 목록 조회 후 그리드 셋팅
            SelectClientList();

            // 그리드 색 변경
            dgvDevice.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 208, 237);
            dgvDevice.DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 208, 237);
            dgvDevice.DefaultCellStyle.SelectionForeColor = Color.Black;

            // 다국어적용
            label1.Text = Global.GetMultiLang("E-TXT-DEV_MNG", "장비현황관리");
            lblClientList.Text = Global.GetMultiLang("E-TXT-DEV_LIST", "장비현황목록");
        }

        #region method
        // 장비 목록 조회 후 그리드 셋팅
        private void SelectClientList()
        {
            // set req params
            var reqParams = new JObject();
            reqParams.Add("comCd", Global.comCd);
            reqParams.Add("plantCd", Global.plantCd);
            reqParams.Add("clientCd", Global.clientSeq);
            reqParams.Add("lang", Global.lang);

            // call api
            string targetUrl = "http://" + Global.svrUrl + "/api/las/selectDeviceList.do";
            JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);

            // 그리드 바인딩
            dgvDevice.Rows.Clear();

            string devNm;
            string parsRuleNm;
            string ptcType;
            string devWatchFolder;
            string serialPort;

            int nRow = 0;
            foreach (JObject data in resultJson["data"])
            {
                devNm = data["devNm"].ToString();
                parsRuleNm = data["parsRuleNm"].ToString();
                ptcType = data["ptcType"].ToString();
                devWatchFolder = data["devWatchFolder"].ToString();
                serialPort = data["serialPort"].ToString();


                // 라인 추가
                nRow = dgvDevice.Rows.Add(devNm, parsRuleNm, null, "설정", devWatchFolder, "찾아보기", "View", "연결여부");

                // 1. 콤보박스값 설정
                if (ptcType.Equals("T"))
                {
                    dgvDevice.Rows[nRow].Cells["ptcType"].Value = "TCP/IP";
                }
                else if (ptcType.Equals("R"))
                {
                    dgvDevice.Rows[nRow].Cells["ptcType"].Value = "RS-232C";
                }

                // 2. 프로토콜 정보 셋팅
                dgvDevice.Rows[nRow].Cells["btnProtocolSetting"].Tag = data;

                // 3. 장비감시폴더 정보 셋팅
                dgvDevice.Rows[nRow].Cells["btnWatchFolder"].Tag = data;

                // 4. Parsing View 링크 셋팅
                dgvDevice.Rows[nRow].Cells["btnParsingView"].Tag = data;

                // 5. 장비 시리얼 연결 여부 체크
                if (ptcType.Equals("R"))
                {
                    if (MainForm.multiSerialPort.ContainsKey(serialPort))
                    {
                        if (MainForm.multiSerialPort[serialPort].IsOpen)
                        {
                            dgvDevice.Rows[nRow].Cells["connYn"].Value = "RS232C 연결됨";
                            dgvDevice.Rows[nRow].Cells["connYn"].Style.ForeColor = Color.Blue;
                        }
                        else
                        {
                            dgvDevice.Rows[nRow].Cells["connYn"].Value = "RS232C 연결안됨";
                            dgvDevice.Rows[nRow].Cells["connYn"].Style.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        dgvDevice.Rows[nRow].Cells["connYn"].Value = "폴더감시";
                        dgvDevice.Rows[nRow].Cells["connYn"].Style.ForeColor = Color.LightGreen;
                    }
                }
                else if (ptcType.Equals("T"))
                {
                    dgvDevice.Rows[nRow].Cells["connYn"].Value = "폴더감시";
                    dgvDevice.Rows[nRow].Cells["connYn"].Style.ForeColor = Color.LightGreen;
                }
            }

            // 불필요한 컬럼은 안보이도록 처리
            dgvDevice.Columns["parsRuleNm"].Visible = false;

            // 재 바인딩시 헤더값이 초기화 되서 명시적으로 넣어줌.
            dgvDevice.Columns["devNm"].HeaderText = "장비명";
            dgvDevice.Columns["parsRuleNm"].HeaderText = "Rule Name";
            dgvDevice.Columns["ptcType"].HeaderText = "프로토콜타입";
            dgvDevice.Columns["btnProtocolSetting"].HeaderText = "프로토콜설정";
            dgvDevice.Columns["devWatchFolder"].HeaderText = "장비감시폴더";
            dgvDevice.Columns["btnWatchFolder"].HeaderText = "장비감시폴더설정";
            dgvDevice.Columns["btnParsingView"].HeaderText = "ParsingView";
            dgvDevice.Columns["connYn"].HeaderText = "연결여부";

            // 가로폭
            dgvDevice.Columns["devNm"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDevice.Columns["parsRuleNm"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDevice.Columns["ptcType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDevice.Columns["btnProtocolSetting"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDevice.Columns["devWatchFolder"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDevice.Columns["btnWatchFolder"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDevice.Columns["btnParsingView"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDevice.Columns["connYn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        #endregion

        #region 그리드 이벤트
        // 셀 클릭시
        private void dgvDevice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            JObject data = (JObject)dgvDevice.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;

            // 프로토콜 설정 클릭시
            if (e.ColumnIndex == 3)
            {
                if (dgvDevice.Rows[e.RowIndex].Cells["ptcType"].Value == null)
                {
                    MessageBox.Show(Global.GetMultiLang("E-MSG-SELECT_PROTOCOL", "프로토콜타입을 선택해 주세요."));
                    return;
                }
                string ptcType = dgvDevice.Rows[e.RowIndex].Cells["ptcType"].Value.ToString();

                DialogResult result = DialogResult.Cancel;
                if (ptcType.Equals("TCP/IP"))
                {
                    data["ptcType"] = "T";
                    TcpSetting tcpSetting = new TcpSetting(data);
                    result = tcpSetting.ShowDialog(this);
                }
                else if (ptcType.Equals("RS-232C"))
                {
                    data["ptcType"] = "R";
                    Rs232Setting rs232Setting = new Rs232Setting(data);
                    result = rs232Setting.ShowDialog(this);
                }

                if (result == DialogResult.OK)
                {
                    // 장비 목록 조회 후 그리드 셋팅
                    SelectClientList();
                }
            }
            // 장비감시폴더 클릭시
            else if (e.ColumnIndex == 5)
            {
                DialogResult result = DialogResult.Cancel;
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string selPath = dialog.SelectedPath;

                    // 1. 서버내 장비감시폴더 정보 업데이트
                    // set req params
                    var reqParams = new JObject();
                    reqParams.Add("comCd", data["comCd"].ToString());
                    reqParams.Add("plantCd", data["plantCd"].ToString());
                    reqParams.Add("clientCd", data["clientCd"].ToString());
                    reqParams.Add("devCd", data["devCd"].ToString());
                    reqParams.Add("devWatchFolder", selPath);
                    // call api
                    string targetUrl = "http://" + Global.svrUrl + "/api/las/insertWatchFolderInfo.do";
                    JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);

                    // 2. 로컬DB 장비감시폴더 정보 업데이트
                    string sql = string.Format(@"UPDATE SCHEDULE_INFO SET DEV_WATCH_FOLDER = '{0}' WHERE DEV_CD = {1}"
                       , selPath
                       , data["devCd"].ToString()
                       );
                    SQLiteHelper.SaveData(sql);

                    MessageBox.Show(Global.GetMultiLang("E-MSG-SAVE_OK", "정상적으로 저장 되었습니다."));

                    // 장비 목록 조회 후 그리드 셋팅
                    SelectClientList();
                }
            }
            // Parsing View 클릭시
            else if (e.ColumnIndex == 6)
            {
                ParsingView parsingView = new ParsingView(data["parsViewLink"].ToString());
                parsingView.ShowDialog(this);
            }
        }

        private void lblClientList_Click(object sender, EventArgs e)
        {

        }

        private void dgvDevice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion
    }
}
