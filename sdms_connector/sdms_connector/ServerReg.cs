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
    public partial class ServerReg : Form
    {
        string selSvrSeq = null;   // 그리드에서 선택된 row의 seq

        public ServerReg(string svrSeq, string svrNm, string svrIp)
        {
            InitializeComponent();

            // 수정일 경우
            selSvrSeq = svrSeq;
            tbServerName.Text = svrNm;
            tbIpPort.Text = svrIp;

            // 다국어적용
            label3.Text = Global.GetMultiLang("E-TXT-SERVER_REG", "서버등록");
            label4.Text = Global.GetMultiLang("E-TXT-SERVER_NAME", "서버명");
            btnSave.Text = Global.GetMultiLang("E-TXT-SAVE", "저장");
            btnCancle.Text = Global.GetMultiLang("E-TXT-CANCLE", "취소");
        }

        // 확인 버튼
        private void btnSave_Click(object sender, EventArgs e)
        {
            // validation
            if (String.IsNullOrEmpty(tbServerName.Text))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "아이디", "서버명은 필수 입력 항목 입니다."));
                return;
            }

            if (String.IsNullOrEmpty(tbIpPort.Text))
            {
                MessageBox.Show(Global.GetMultiLang("E-MSG-INPUT_REQURIED", "아이디", "IP:PORT는 필수 입력 항목 입니다."));
                return;
            }

            // insert
            string sql;
            if (string.IsNullOrEmpty(selSvrSeq))
            {
                sql = @"INSERT INTO SVR_INFO(SVR_NM, SVR_IP, REG_DT, REG_ID, MOD_DT, MOD_ID) VALUES
                        ('" + tbServerName.Text + "', '" + tbIpPort.Text + "', datetime(), '" + Global.userPk + "', datetime(), '" + Global.userPk + "')";
            }
            // update
            else
            {
                sql = string.Format("UPDATE SVR_INFO SET SVR_NM = '{0}', SVR_IP = '{1}', MOD_DT = datetime(), MOD_ID = '{2}' WHERE SVR_SEQ = {3}"
                    , tbServerName.Text
                    , tbIpPort.Text
                    , Global.userPk
                    , selSvrSeq);
            }

            SQLiteHelper.SaveData(sql);

            MessageBox.Show(Global.GetMultiLang("E-MSG-SAVE_OK", "정상적으로 저장 되었습니다."));
            this.Close();
        }

        // 취소 버튼
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
