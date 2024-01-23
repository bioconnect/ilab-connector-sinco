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

namespace LASConnector
{
    public partial class Login : Form
    {
        public delegate void FrmSendDataHandler(Object obj);
        public event FrmSendDataHandler FrmSendEvent;

        public string svrNm;
        public string svrIp;

        public Login()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(Login) init!"));

            InitializeComponent(); //윈폼을 만들고 디자인한 내용을 적용시키기 위해서 cs 생성자의 호출한다.

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

            tbUserID.BackColor = Color.White; //ID 입력창 배경 컬러
            tbPwd.BackColor = Color.White; // PassWord 입력창 배경 컬러
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
                MessageBox.Show("입력하신 아이디에 해당하는 플랜트 정보가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            reqParams2.Add("pageId", "LA_CONNECTOR01");

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
            if (String.IsNullOrEmpty(tbServer.Text)) //서버등록 텍스트박스의 텍스트가 널값이거나 공백일때
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "서버정보", "서버정보는 필수 입력 항목 입니다."));
                tbServer.Focus();
                return;
            }
            //ID 텍스트 박스의 텍스트가 널값, 공백이거나 텍스트 박스의 ID가 적혀있을 경우(기본값이 ID)
            if (String.IsNullOrEmpty(tbUserID.Text) || tbUserID.Text.Equals("ID"))
            {   //아이디 조건이 맞지 않았을 경우 알림창 내용
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "아이디", "아이디는 필수 입력 항목 입니다."));
                tbUserID.Focus(); //위 문장 실행 후 ID 창에 입력 표시가 들어간다
                return;
            }
            // PassWord 텍스트 박스의 텍스트가 널값, 공백이거나 텍스트 박스의 PASSWORD가 적혀있을 경우 (기본값이 PASSWORD)
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
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "언어", "언어는 필수 입력 항목 입니다."));
                cbLanguage.Focus();
                return;
            }

            Cursor.Current = Cursors.WaitCursor; // 모래시계 커서
            // set req params
            var reqParams = new JObject();
            reqParams.Add("lang", cbLanguage.SelectedValue.ToString());
            reqParams.Add("userId", tbUserID.Text);
            reqParams.Add("currPw", tbPwd.Text);
            reqParams.Add("comCd", Global.comCd);
            reqParams.Add("plantCd", cbPlant.SelectedValue.ToString());

            // call
            string targetUrl = "http://" + tbServer.Tag + "/api/config/login.do";
            JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl); // 타겟 url에 reqParams에 추가된 값을 요청함

            // response - 정상로그인시 서버url, 플랜트코드는 글로벌 값으로 셋팅함.
            Global.svrUrl = tbServer.Tag.ToString();
            Global.plantCd = cbPlant.SelectedValue.ToString();
            Global.lang = cbLanguage.SelectedValue.ToString();

            // Set 다국어
            SetMultiLanguage(cbLanguage.SelectedValue.ToString(), cbPlant.SelectedValue.ToString());

            // 로그인폼에서 메인폼에 이벤트 전달
            this.FrmSendEvent(resultJson);

            Cursor.Current = Cursors.Default;

            #region for test
            //// set req params
            //JObject resultJson = new JObject();
            //resultJson.Add("userId", "test");
            //resultJson.Add("userPk", "4");
            //resultJson.Add("userNm", "홍길동");
            //resultJson.Add("deptNm", "생산본부");
            //resultJson.Add("teamNm", "QC팀");
            //resultJson.Add("authToken", "1111111111111111");

            //// 로그인폼에서 메인폼에 이벤트 전달
            //Global.svrUrl = tbServer.Tag.ToString();
            //Global.plantCd = "0000";

            //this.FrmSendEvent(resultJson);
            #endregion
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
            if (string.IsNullOrEmpty(tbUserID.Text)) //ID 텍스트박의 텍스트가 공백이거나 널값이면
            {
                tbUserID.Text = "ID"; //ID 기본값이 ID로 설정
                tbUserID.ForeColor = Color.Gray; //글씨 색
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
            if (string.IsNullOrEmpty(tbPwd.Text)) // PassWord 텍스트 박스의 텍스트가 널값이거나 공백일 경우
            {
                tbPwd.PasswordChar = '\0';

                tbPwd.Text = "PASSWORD";
                tbPwd.ForeColor = Color.Gray;
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
            tbUserID.Text = string.Empty; // ID 텍스트 박스가 공백란이 됨
            tbUserID.ForeColor = Color.Black; //아이디 입력 시 글자 색
        }

        // 패스워드 입력폼 클릭시
        private void tbPwd_GotFocus(object sender, EventArgs e)
        {
            tbPwd.Text = string.Empty; // PassWord 텍스트 박스가 공백란이 됨
            tbPwd.ForeColor = Color.Black; //패스워드 입력 시 글자 색

            tbPwd.PasswordChar = '*';   //패스워드 출력 방식
        }

        #endregion

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void tbServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
