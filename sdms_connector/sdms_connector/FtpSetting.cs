using LSP.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sdms_connector
{
    public partial class FtpSetting : Form
    {
        public FtpSetting()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang(FtpSetting) init!"));

            InitializeComponent();

            // FTP 저장 정보 불러오기
            string sql = "SELECT FTP_NM, FTP_IP, FTP_ID, FTP_PWD FROM BASIC_INFO";
            DataTable dt = SQLiteHelper.SelectDataSet(sql).Tables[0];
            tbFtpName.Text = dt.Rows[0]["FTP_NM"].ToString();
            tbFtpIp.Text = dt.Rows[0]["FTP_IP"].ToString();
            tbFtpId.Text = dt.Rows[0]["FTP_ID"].ToString();
            tbFtpPwd.Text = dt.Rows[0]["FTP_PWD"].ToString();

            SetGlobalFtpInfo();

            // 클라이언트 설정이 안되면 테스트 버튼 비활성화
            if (String.IsNullOrEmpty(Global.clientID))
                btnTest.Enabled = false;
        }
        #region method
        // Ftp 업로드 테스트 
        public void FtpUploadTest()
        {
            string ftpPath = "ftp://" + tbFtpIp.Text + "/" + Global.clientSeq + "_test";
            string user = tbFtpId.Text;
            string pwd = tbFtpPwd.Text;

            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(ftpPath);
            req.Method = WebRequestMethods.Ftp.AppendFile;
            req.Credentials = new NetworkCredential(user, pwd);

            byte[] data = Encoding.UTF8.GetBytes(Global.clientSeq + " 접속 테스트(" + DateTime.Now.ToString() + ")\n");

            try
            {
                // RequestStream에 데이타를 쓴다
                req.ContentLength = data.Length;
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                }

                // FTP Upload 실행
                using (FtpWebResponse resp = (FtpWebResponse)req.GetResponse())
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("kskang(FtpUploadTest) resp.StatusDescription = {0}", resp.StatusDescription));
                    resp.Close();
                    MessageBox.Show("FTP 접속이 정상적으로 테스트 되었습니다.");
                }
            }
            catch
            {
                MessageBox.Show("FTP 접속이 실패하였습니다. 접속정보를 다시 확인해 주시기 바랍니다.");
            }
        }

        // ftp global 정보 셋팅
        public void SetGlobalFtpInfo()
        {
            Global.ftpIP = tbFtpIp.Text;
            Global.ftpID = tbFtpId.Text;
            Global.ftpPWD = tbFtpPwd.Text;
        }
        #endregion

        #region 버튼 이벤트
        // FTP 테스트
        private void btnTest_Click(object sender, EventArgs e)
        {
            FtpUploadTest();
        }

        // FTP 정보 저장
        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = string.Format("UPDATE BASIC_INFO SET FTP_NM = '{0}', FTP_IP = '{1}', FTP_ID = '{2}', FTP_PWD = '{3}'", tbFtpName.Text, tbFtpIp.Text, tbFtpId.Text, tbFtpPwd.Text);
            SQLiteHelper.SaveData(sql);

            // ftp global 정보 셋팅
            SetGlobalFtpInfo();

            MessageBox.Show(Global.GetMultiLang("E-MSG-SAVE_OK", "정상적으로 저장 되었습니다."));
        }
        #endregion
    }
}
