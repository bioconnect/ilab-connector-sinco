using LSP.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace sdms_connector
{
    public partial class SignForm : Form
    {
        public SignForm()
        {
            InitializeComponent();

            // Set basic code
            SetBasicInfo();

            // TextBox Event
            userID.GotFocus += userID_GotFocus;
            signPw.GotFocus += signPw_GotFocus;

            ActiveInputControl();
        }
        
        private void SetBasicInfo()
        {
            // 회사코드
            string sql = "SELECT COM_CD FROM BASIC_INFO";
            Global.comCd = SQLiteHelper.SelectDataSet(sql).Tables[0].Rows[0]["COM_CD"].ToString();

            // 서버 URL
            sql = "SELECT SVR_NM, SVR_IP FROM SVR_INFO WHERE DEFAULT_YN = 'Y'";
            DataTable dt = SQLiteHelper.SelectDataSet(sql).Tables[0];

        }

        private void ActiveInputControl()
        {
            userID.Enabled = true;
            signPw.Enabled = true;

            userID.BackColor = Color.White;
            signPw.BackColor = Color.White;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(userID.Text) || userID.Text.Equals("ID"))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "아이디", "아이디는 필수 입력 항목 입니다."));
                userID.Focus();
                return;
            }
            
            if (string.IsNullOrEmpty(signPw.Text) || signPw.Text.Equals("PASSWORD"))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "비밀번호", "비밀번호는 필수 입력 항목 입니다."));
                signPw.Focus();
                return;
            }
            
            Cursor.Current = Cursors.WaitCursor;
            // set req params
            var reqParams = new JObject();
            reqParams.Add("userId", Global.userId);
            reqParams.Add("signUserId", userID.Text);
            reqParams.Add("signPw", signPw.Text);
            reqParams.Add("clientIP", Global.clientIP);
            reqParams.Add("comCd",Global.comCd);
            reqParams.Add("plantCd",Global.plantCd);
            
            System.Diagnostics.Debug.WriteLine("<<<< Login Params >>>>" + reqParams);
            
            string targetUrl = "http://" +  Global.svrUrl + "/api/config/matchSignPw.do";
            JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);

            System.Diagnostics.Debug.WriteLine("<<<< resultJson >>>>" + resultJson);
            if (resultJson["result"].ToString().Equals("success"))
            {
                MessageBox.Show(@"전자 서명에 성공하였습니다.");
                this.Close();
            }

            if (resultJson["result"].ToString().Equals("fail"))
            {
                MessageBox.Show((string)resultJson["msg"]);
            }

        }

        private void userID_GotFocus(object sender, EventArgs e)
        {
            userID.Text = string.Empty;
            userID.ForeColor = Color.Black;
        }

        private void signPw_GotFocus(object sender, EventArgs e)
        {
            signPw.Text = string.Empty;
            signPw.ForeColor = Color.Black;
            signPw.PasswordChar = '*';
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}