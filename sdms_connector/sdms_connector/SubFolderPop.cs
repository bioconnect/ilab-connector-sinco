using LSP.Common;
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

namespace sdms_connector
{
    public partial class SubFolderPop : Form
    {
        private string activateFrm;

        public SubFolderPop(string activateFrm)
        {
            InitializeComponent();

            // 프로젝트트리 목록 조회 후 트리생성
            SelectTreeList();

            this.activateFrm = activateFrm;

            // 다국어적용
            label1.Text = Global.GetMultiLang("E-TXT-SUBFOLDER", "서브폴더");
            label2.Text = Global.GetMultiLang("E-TXT-SEL_SUBFOLDER", "서브폴더를 선택하세요.");
            label3.Text = Global.GetMultiLang("E-TXT-SUBFOLDER", "서브폴더");
            btnConfirm.Text = Global.GetMultiLang("E-TXT-CONFIRM", "확인");
            btnCancle.Text = Global.GetMultiLang("E-TXT-CANCLE", "취소");
        }

        #region method
        // 프로젝트트리 목록 조회 후 트리생성
        private void SelectTreeList()
        {
            // set req params
            var reqParams = new JObject();
            reqParams.Add("clientSeq", Global.clientSeq);
            reqParams.Add("comCd", Global.comCd);
            reqParams.Add("plantCd", Global.plantCd);
            reqParams.Add("userId", Global.userId);

            // call api
            string targetUrl = "http://" + Global.svrUrl + "/api/sdms/selectSubFolder.do";
            JObject resultJson = RestApiRequest.CallSync(reqParams, targetUrl);
            // 테스트데이터
            //String result = "{\"result\":\"success\",\"msg\":\"\",\"data\":[{\"projCd\":5,\"projNm\":\"프로젝트A\",\"folderCd\":0,\"subFolderCd\":0,\"sort\":\"000500000000\",\"text\":\"프로젝트A\",\"folderType\":\"proj\"},{\"projCd\":5,\"projNm\":\"프로젝트A\",\"folderCd\":4,\"folderNm\":\"폴더1\",\"subFolderCd\":0,\"sort\":\"000500040000\",\"text\":\"폴더1\",\"folderType\":\"folder\"},{\"projCd\":6,\"projNm\":\"프로젝트B\",\"folderCd\":0,\"subFolderCd\":0,\"sort\":\"000600000000\",\"text\":\"프로젝트B\",\"folderType\":\"proj\"},{\"projCd\":6,\"projNm\":\"프로젝트B\",\"folderCd\":5,\"folderNm\":\"폴더2\",\"subFolderCd\":0,\"sort\":\"000600050000\",\"text\":\"폴더2\",\"folderType\":\"folder\"},{\"projCd\":6,\"projNm\":\"프로젝트B\",\"folderCd\":5,\"folderNm\":\"폴더2\",\"subFolderCd\":7,\"sort\":\"000600050007\",\"text\":\"서브1+PDF\",\"folderType\":\"subfolder\",\"subFolderDiv\":\"p\"},{\"projCd\":6,\"projNm\":\"프로젝트B\",\"folderCd\":5,\"folderNm\":\"폴더2\",\"subFolderCd\":8,\"sort\":\"000600050008\",\"text\":\"서브1 RAW\",\"folderType\":\"subfolder\",\"subFolderDiv\":\"r\"},{\"projCd\":6,\"projNm\":\"프로젝트B\",\"folderCd\":5,\"folderNm\":\"폴더2\",\"subFolderCd\":9,\"sort\":\"000600050009\",\"text\":\"333\",\"folderType\":\"subfolder\",\"subFolderDiv\":\"r\"},{\"projCd\":6,\"projNm\":\"프로젝트B\",\"folderCd\":6,\"folderNm\":\"폴더3\",\"subFolderCd\":0,\"sort\":\"000600060000\",\"text\":\"폴더3\",\"folderType\":\"folder\"}]}";
            //JObject resultJson = JObject.Parse(result);


            // 트리생성
            TreeNode proj = null;
            TreeNode folder = null;
            TreeNode subfolder = null;
            foreach (JObject data in resultJson["data"])
            {
                if (data["folderType"].ToString().Equals("proj"))
                {
                    //System.Diagnostics.Debug.WriteLine(string.Format("kskang: text,folderType = {0},{1}", data["text"], data["folderType"]));
                    proj = null;
                    proj = new TreeNode(data["projNm"].ToString());
                    proj.Tag = data;
                    tvProject.Nodes.Add(proj);
                }
                else if (data["folderType"].ToString().Equals("folder"))
                {
                    //System.Diagnostics.Debug.WriteLine(string.Format("kskang: text,folderType = {0},{1}", data["text"], data["folderType"]));
                    folder = null;
                    folder = new TreeNode(data["folderNm"].ToString());
                    folder.Tag = data;
                    proj.Nodes.Add(folder);
                }
                else if (data["folderType"].ToString().Equals("subfolder"))
                {
                    //System.Diagnostics.Debug.WriteLine(string.Format("kskang: text,folderType = {0},{1}", data["text"], data["folderType"]));
                    subfolder = null;
                    subfolder = new TreeNode(data["text"].ToString());
                    subfolder.Tag = data;
                    
                    if (data["subFolderDiv"].ToString().Equals("p"))
                    {
                        subfolder.ImageIndex = 2;
                        subfolder.SelectedImageIndex = 2;
                    }
                    else if (data["subFolderDiv"].ToString().Equals("r"))
                    {
                        subfolder.ImageIndex = 3;
                        subfolder.SelectedImageIndex = 3;
                    }

                    folder.Nodes.Add(subfolder);
                }
            }
        }
        #endregion 

        #region 이벤트
        // 서브폴더 선택시 이벤트
        private void tvProject_AfterSelect(object sender, TreeViewEventArgs e)
        {
            JObject json = (JObject)tvProject.SelectedNode.Tag;
            if (json["folderType"].ToString().Equals("subfolder"))
            {
                hiddenProjCd.Text = json["projCd"].ToString();
                hiddenFolderCd.Text = json["folderCd"].ToString();
                hiddenSubFolderCd.Text = json["subFolderCd"].ToString();
                tbSubFolderNm.Text = json["projNm"].ToString() + @"\" + json["folderNm"].ToString() + @"\" + json["text"].ToString();

                btnConfirm.Enabled = true;
            }
            else
            {
                btnConfirm.Enabled = false;
            }
        }

        // 확인버튼 클릭시
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (activateFrm.Equals("scheduleMngFrm"))
            {
                SubForm subForm = (SubForm)this.Owner.ActiveControl;
                ScheduleMng scheduleMng = (ScheduleMng)subForm.ActiveControl;

                scheduleMng.projCd = hiddenProjCd.Text;
                scheduleMng.folderCd = hiddenFolderCd.Text;
                scheduleMng.subfolderCd = hiddenSubFolderCd.Text;
                scheduleMng.subfolderNm = tbSubFolderNm.Text;
            }
            else if (activateFrm.Equals("pdfFrm"))
            {
                PdfForm pdfForm = (PdfForm)this.Owner.ActiveControl;

                pdfForm.projCd = hiddenProjCd.Text;
                pdfForm.folderCd = hiddenFolderCd.Text;
                pdfForm.subfolderCd = hiddenSubFolderCd.Text;
                pdfForm.subfolderNm = tbSubFolderNm.Text;
            }

            this.Close();
        }

        // 취소버튼 클릭시
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 노드 클릭시
        private void tvProject_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang: tvProject_NodeMouseClick(Text,IsExpanded) = {0},{1}", e.Node.Text, e.Node.IsExpanded));

            // 서브폴더가 아닐때만 아이콘 열림, 닫힘 표시
            if (!((JObject)e.Node.Tag)["folderType"].ToString().Equals("subfolder"))
            {
                // open
                if (e.Node.IsExpanded)
                {
                    e.Node.ImageIndex = 1;
                }
                // close
                else
                {
                    e.Node.ImageIndex = 0;
                }
            }
        }
        #endregion
    }
}
