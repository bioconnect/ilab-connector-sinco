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
using System.Net;
using System.IO;

using Newtonsoft.Json.Linq;
using LSP.Common;

namespace sdms_connector
{
    public partial class Login : Form
    {
        public delegate void FrmSendDataHandler(Object obj);
        public event FrmSendDataHandler FrmSendEvent;

        public string svrNm;
        public string svrIp;
        static public JObject req_send;
        static public string tbServer_send;
        static public string req_min;
        static public string req_max;

        public Login()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(Login) init!"));

            InitializeComponent();

            // Set 기본코드(회사코드, 서버 URL)
            SetBasicInfo();

            // 텍스트박스 이벤트
            tbUserID.GotFocus += tbUserID_GotFocus;
            tbPwd.GotFocus += tbPwd_GotFocus;

            // Set 다국어
            //SetMultiLanguage("df", "0000");
        }

        #region method
        //  Set 기본코드(회사코드, 서버 URL)
        private void SetBasicInfo()
        {
            // 회사코드
            string sql = "SELECT COM_CD FROM BASIC_INFO";
            Global.comCd = SQLiteHelper.SelectDataSet(sql).Tables[0].Rows[0]["COM_CD"].ToString();

            // 서버 URL
            sql = "SELECT SVR_NM, SVR_IP FROM SVR_INFO WHERE DEFAULT_YN = 'Y'";
            DataTable dt = SQLiteHelper.SelectDataSet(sql).Tables[0];

            if (dt.Rows.Count > 0)
            {
                tbServer.Text = dt.Rows[0]["SVR_NM"].ToString();
                tbServer.Tag = dt.Rows[0]["SVR_IP"].ToString();
                // 입력필드 활성화
                ActiveInputControl();
            }
        }

        // 입력필드 활성화
        private void ActiveInputControl()
        {
            tbUserID.Enabled = true;
            tbPwd.Enabled = true;
            cbLanguage.Enabled = true;
            cbPlant.Enabled = true;

            tbUserID.BackColor = Color.White;
            tbPwd.BackColor = Color.White;
        }

        // Set 언어리스트박스
        private void SetLanguageList()
        {
            // set req params
            var reqParams = new JObject();
            reqParams.Add("lang", "df");
            reqParams.Add("comCd", Global.comCd);
            reqParams.Add("plantCd", cbPlant.SelectedValue.ToString());
            reqParams.Add("hcodeCd", "SYS00002");

            // call api
            string targetUrl = "http://" + tbServer.Tag + "/api/config/selectLanguage.do";
            JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);

            // response -  set comboboxlist
            if (resultJson["data"].Count() != 0)
            {
                cbLanguage.DataSource = resultJson["data"];
                cbLanguage.ValueMember = "codeCd";
                cbLanguage.DisplayMember = "codeDf";

                cbLanguage.Enabled = true;
            }
            else
            {
                cbLanguage.DataSource = null;
                cbLanguage.Enabled = false;
            }
        }

        // Set 플랜트리스트박스
        private void SetPlantList()
        {
            // set req params
            var reqParams = new JObject();
            reqParams.Add("comCd", Global.comCd);
            reqParams.Add("userId", tbUserID.Text);

            // call api
            string targetUrl = "http://" + tbServer.Tag + "/api/config/selectPlant.do";
            JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);

            // response 
            if (!resultJson["cnt"].ToString().Equals("0"))
            {
                // set comboboxlist
                cbPlant.DataSource = resultJson["data"];
                cbPlant.ValueMember = "plantCd";
                cbPlant.DisplayMember = "plantName";

                cbPlant.Enabled = true;

                // Set 언어리스트박스
                SetLanguageList();
            }
            else
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-CHECK_ID", "아이디를 확인해 주세요."), "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cbPlant.DataSource = null;
                cbPlant.Enabled = false;

                cbLanguage.DataSource = null;
                cbLanguage.Enabled = false;
            }
        }
        
        // Set 다국어
        private void SetMultiLanguage(string lang, string plant)
        {
            // set req params
            var reqParams2 = new JObject();
            reqParams2.Add("lang", lang);
            reqParams2.Add("comCd", Global.comCd);
            reqParams2.Add("plantCd", plant);
            reqParams2.Add("pageId", "SM_CONNECTOR01");

            // call
            string targetUrl2 = "http://" + tbServer.Tag + "/api/config/selectPageLanguage.do";
            JObject resultJson2 = RestApiRequest.CallSync(reqParams2, targetUrl2);

            Global.ResetMultiLang();
            foreach (JObject data in resultJson2["data"])
            {
                Global.SetMultiLang(data["clsLink"].ToString(), data["msg"].ToString());
            }
        }
        #endregion

        #region 컨트롤 이벤트
        // 로그인 버튼 클릭시
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbServer.Text))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "서버정보", "서버정보는 필수 입력 항목 입니다."));

                tbServer.Focus();
                return;
            }

            if (String.IsNullOrEmpty(tbUserID.Text) || tbUserID.Text.Equals("ID"))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "아이디", "아이디는 필수 입력 항목 입니다."));

                tbUserID.Focus();
                return;
            }

            if (String.IsNullOrEmpty(tbPwd.Text) || tbPwd.Text.Equals("PASSWORD"))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "비밀번호", "비밀번호는 필수 입력 항목 입니다."));
                tbPwd.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cbPlant.Text))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "플랜트", "플랜트는 필수 입력 항목 입니다."));
                cbPlant.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cbLanguage.Text))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "언어", "플랜트는 필수 입력 항목 입니다."));
                cbLanguage.Focus();
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            // set req params
            var reqParams = new JObject();
            reqParams.Add("lang", cbLanguage.SelectedValue.ToString());
            reqParams.Add("userId", tbUserID.Text);
            reqParams.Add("currPw", tbPwd.Text);
            reqParams.Add("comCd", Global.comCd);
            reqParams.Add("plantCd", cbPlant.SelectedValue.ToString());

            // call
            string targetUrl = "http://" + tbServer.Tag + "/api/config/login.do";
            JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);
            tbServer_send = tbServer.Tag.ToString();
            req_send = reqParams;
            req_min = resultJson["minCnt"].ToString();
            req_max = resultJson["maxCnt"].ToString();
            int numToEndDate = Convert.ToInt32(resultJson["daysToEndDate"].ToString());
            if (numToEndDate < 10)
            {
                MessageBox.Show("password 만료 기간까지 " + numToEndDate + "일 남았습니다.");
            }
            if (resultJson["pwModWh"].ToString().Equals("C") && numToEndDate > 0)
            {
                // response - 정상로그인시 서버url, 플랜트코드는 글로벌 값으로 셋팅함.
                Global.svrUrl = tbServer.Tag.ToString();
                Global.plantCd = cbPlant.SelectedValue.ToString();

                // Set 다국어
                SetMultiLanguage(cbLanguage.SelectedValue.ToString(), cbPlant.SelectedValue.ToString());
                MessageBox.Show("로그인을 성공하였습니다.");
                // 로그인폼에서 메인폼에 이벤트 전달
                this.FrmSendEvent(resultJson);

                Cursor.Current = Cursors.Default;
            }
            if (resultJson["pwModWh"].ToString().Equals("A") || numToEndDate <= 0)
            {
                SetBasicInfo();
                Password_Change_Form pCF = new Password_Change_Form();
                pCF.ShowDialog();
            }
        }

        // 서버셋팅 버튼 클릭시
        private void btnSvrSetting_Click(object sender, EventArgs e)
        {
            ServerMng serverMng = new ServerMng();
            DialogResult ds = serverMng.ShowDialog(this);

            if (ds == DialogResult.OK)
            {
                tbServer.Text = svrNm;
                tbServer.Tag = svrIp;

                // 입력필드 활성화
                ActiveInputControl();
            }
        }

        // 아이디 입력폼 떠날 경우
        private void tbUserID_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUserID.Text))
            {
                tbUserID.Text = "ID";
                tbUserID.ForeColor = Color.Gray;
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;

                // Set 플랜트 리스트박스
                SetPlantList();

                Cursor.Current = Cursors.Default;
            }
        }

        // 패스워드 입력폼 떠날 경우
        private void tbPwd_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbPwd.Text))
            {
                tbPwd.Text = "PASSWORD";
                tbPwd.ForeColor = Color.Gray;

                tbPwd.PasswordChar = '\0';
            }
        }

        // 플랜트 변경시
        private void cbPlant_SelectionChangeCommitted(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(MainForm) cbPlant_SelectionChangeCommitted"));

            // Set 언어리스트박스
            SetLanguageList();
        }

        // 사용자아이디 입력폼 클릭시
        private void tbUserID_GotFocus(object sender, EventArgs e)
        {
            tbUserID.Text = string.Empty;
            tbUserID.ForeColor = Color.Black;
        }

        // 패스워드 입력폼 클릭시
        private void tbPwd_GotFocus(object sender, EventArgs e)
        {
            tbPwd.Text = string.Empty;
            tbPwd.ForeColor = Color.Black;
            tbPwd.PasswordChar = '*';
        }
        #endregion
    }

    #region 비밀번호 변경 이벤트
    public class Password_Change_Form : Form
    {
        private TextBox newPWTextBox;
        private TextBox checkPWTextBox;
        private Button confirmButton;
        private Button cancleButton;
        static public string newPWText;

        public bool test = false;
        TextBox[] txtList;
        const string npwPlaceholder = "신규 비밀번호를 입력해주세요.";
        const string cpwPlaceholder = "비밀번호 재입력해주세요.";

        public Password_Change_Form()
        {
            InitializeComponent();
            defaultValues();
        }
        private void defaultValues()
        {
            //ID, Password TextBox Placeholder 설정
            txtList = new TextBox[] { newPWTextBox, checkPWTextBox };
            foreach (var txt in txtList)
            {
                //처음 공백 Placeholder 지정
                txt.ForeColor = Color.DarkGray;
                if (txt == newPWTextBox) txt.Text = npwPlaceholder;
                else if (txt == checkPWTextBox) txt.Text = cpwPlaceholder;
                //텍스트박스 커서 Focus 여부에 따라 이벤트 지정
                txt.GotFocus += RemovePlaceholder;
                txt.LostFocus += SetPlaceholder;
            }
        }
        private void InitializeComponent()
        {
            newPWTextBox = new TextBox
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(200, 25),
            };

            checkPWTextBox = new TextBox
            {
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(200, 25)
            };

            confirmButton = new Button
            {
                Location = new System.Drawing.Point(10, 100),
                Size = new System.Drawing.Size(75, 30),
                Text = "확인"

            };

            cancleButton = new Button
            {
                Location = new System.Drawing.Point(100, 100),
                Size = new System.Drawing.Size(75, 30),
                Text = "취소"
            };
            confirmButton.Click += confirmButton_Click;
            cancleButton.Click += cancleButton_Click;
            newPWTextBox.PasswordChar = '*';
            newPWTextBox.MaxLength = int.Parse(Login.req_max);
            checkPWTextBox.PasswordChar = '*';
            checkPWTextBox.MaxLength = int.Parse(Login.req_max);
            Controls.Add(newPWTextBox);
            Controls.Add(checkPWTextBox);
            Controls.Add(confirmButton);
            Controls.Add(cancleButton);

            Size = new System.Drawing.Size(250, 150);
            Text = "Password Change";
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            var reqParam = Login.req_send;
            if (newPWTextBox.Text != checkPWTextBox.Text) 
            {
                MessageBox.Show("암호가 일치하지 않습니다. \n 다시 입력해주세요.");
                defaultValues();
            }
            else if (newPWTextBox.Text.Length == 1)
            {
                MessageBox.Show("변경하실 비밀번호를 입력해주세요.");
                defaultValues();
            }
            else if (newPWTextBox.Text.Length < int.Parse(Login.req_min))
            {
                MessageBox.Show("변경하실 비밀번호를 최소"+ int.Parse(Login.req_min) + "자 이상 입력해주세요.");
                defaultValues();
            }
            else if (int.Parse(Login.req_min) < int.Parse(Login.req_max) && newPWTextBox.Text.Length > int.Parse(Login.req_max))
            {
                MessageBox.Show("변경하실 비밀번호를 " + int.Parse(Login.req_max) + "자 미만으로 입력해주세요.");
                defaultValues();
            }
            else if (newPWTextBox.Text == reqParam["currPw"].ToString())
            {
                MessageBox.Show("기존 암호와 동일합니다. \n 다시 입력해주세요.");
                defaultValues();
            }
            else
            {
                if (!reqParam.ContainsKey("newPw"))
                {
                    reqParam.Add("newPw", newPWTextBox.Text);
                }
                else if (reqParam.ContainsKey("newPw"))
                {
                    reqParam["newPw"] = newPWTextBox.Text;
                }
                // call
                string targetUrl = "http://" + Login.tbServer_send + "/api/config/login.do";
                JObject resultJson = RestApiRequest.CallSync(reqParam, targetUrl);

                if (resultJson["result"].ToString().Equals("false"))
                {
                    MessageBox.Show("암호가 정상적으로 변경되지 못하였습니다. \n 다시 입력해주세요.");
                    defaultValues();
                }
                else
                {
                    MessageBox.Show("암호가 정상적 변경되었습니다. \n 변경된 비밀번호로 다시 로그인 해주세요.");
                    this.Close();
                }
            }
        }
        private void cancleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

            private void RemovePlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text == npwPlaceholder | txt.Text == cpwPlaceholder)
            { //텍스트박스 내용이 사용자가 입력한 값이 아닌 Placeholder일 경우에만, 커서 포커스일때 빈칸으로 만들기
                txt.ForeColor = Color.Black; //사용자 입력 진한 글씨
                txt.Text = string.Empty;
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                //사용자 입력값이 하나도 없는 경우에 포커스 잃으면 Placeholder 적용해주기
                txt.ForeColor = Color.DarkGray; //Placeholder 흐린 글씨
                if (txt == newPWTextBox) txt.Text = npwPlaceholder;
                else if (txt == checkPWTextBox) { txt.Text = cpwPlaceholder; checkPWTextBox.PasswordChar = default; }
            }
        }
    }
    #endregion
}
