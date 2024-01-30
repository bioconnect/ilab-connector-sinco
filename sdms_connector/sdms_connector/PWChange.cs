using System;
using System.Windows.Forms;
using System.Drawing;


namespace sdms_connector
{
    public class PWChange : Form
    {
        private TextBox newPWTextBox;
        private TextBox checkPWTextBox;
        private Button confirmButton;
        private Button cancleButton;

        public bool test = false;
        TextBox[] txtList;
        const string IdPlaceholder = "신규 비밀번호를 입력해주세요.";
        const string PwPlaceholder = "비밀번호 재입력해주세요.";

        public PWChange()
        {
            InitializeComponent();

            //ID, Password TextBox Placeholder 설정
            txtList = new TextBox[] { newPWTextBox, checkPWTextBox };
            foreach (var txt in txtList)
            {
                //처음 공백 Placeholder 지정
                txt.ForeColor = Color.DarkGray;
                if (txt == newPWTextBox) txt.Text = IdPlaceholder;
                else if (txt == checkPWTextBox) txt.Text = PwPlaceholder;
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
                Size = new System.Drawing.Size(200, 25)
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

            Controls.Add(newPWTextBox);
            Controls.Add(checkPWTextBox);
            Controls.Add(confirmButton);
            Controls.Add(cancleButton);

            Size = new System.Drawing.Size(250, 150);
            Text = "Password Change";
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            string change_pw = newPWTextBox.Text;

            MessageBox.Show("수정된 비밀번호를 확인합니다 -> ", change_pw);
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text == IdPlaceholder | txt.Text == PwPlaceholder)
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
                if (txt == newPWTextBox) txt.Text = IdPlaceholder;
                else if (txt == checkPWTextBox) { txt.Text = PwPlaceholder; checkPWTextBox.PasswordChar = default; }
            }
        }
    }
}