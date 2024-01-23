using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LSP.Common
{
    public class FTPApi
    {
        public static bool Upload(string ftpPath, string inputFile)
        {
            // log출력: 이전 Class명, 함수명
            string prevClassName = new StackTrace().GetFrame(1).GetMethod().ReflectedType.Name;
            string prevFuncName = new StackFrame(1, true).GetMethod().Name;
            System.Diagnostics.Debug.WriteLine(string.Format("FTPLOG({0}:{1}:FTPApi.Upload): ftpPath = {2}", prevClassName, prevFuncName, ftpPath));
            System.Diagnostics.Debug.WriteLine(string.Format("FTPLOG({0}:{1}:FTPApi.Upload): inputFile = {2}", prevClassName, prevFuncName, inputFile));


            try
            {
                FtpWebRequest req = (FtpWebRequest)WebRequest.Create("ftp://" + Global.ftpIP + "/" + ftpPath);
                req.Method = WebRequestMethods.Ftp.UploadFile;
                req.Credentials = new NetworkCredential(Global.ftpID, Global.ftpPWD);


                // 입력파일을 바이트 배열로 읽음
                byte[] data;
                using (StreamReader reader = new StreamReader(inputFile))
                {
                    data = Encoding.UTF8.GetBytes(reader.ReadToEnd());
                }

                // RequestStream에 데이타를 쓴다
                req.ContentLength = data.Length;
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                }

                // FTP Upload 실행
                using (FtpWebResponse resp = (FtpWebResponse)req.GetResponse())
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("FTPLOG({0}:{1}:FTPApi.Upload): resp.StatusDescription = {2}", prevClassName, prevFuncName, resp.StatusDescription));
                    resp.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("FTPLOG({0}:{1}:FTPApi.Upload): ex = {2}", prevClassName, prevFuncName, ex.ToString()));
                throw new Exception(ex.Message);
                return true;
            }
        }

        public static JObject Upload(string targetUrl, string reqParams, string filePath)
        {
            JObject resultJson = null;
            // log출력: 이전 Class명, 함수명
            string prevClassName = new StackTrace().GetFrame(1).GetMethod().ReflectedType.Name;
            string prevFuncName = new StackFrame(1, true).GetMethod().Name;
            System.Diagnostics.Debug.WriteLine(string.Format("FTPLOG({0}:{1}:FTPApi.Upload): targetUrl = {2}", prevClassName, prevFuncName, targetUrl));
            System.Diagnostics.Debug.WriteLine(string.Format("FTPLOG({0}:{1}:FTPApi.Upload): reqParams = {2}", prevClassName, prevFuncName, reqParams));
            System.Diagnostics.Debug.WriteLine(string.Format("FTPLOG({0}:{1}:FTPApi.Upload): filePath = {2}", prevClassName, prevFuncName, filePath));
            System.Diagnostics.Debug.WriteLine(string.Format("FTPLOG({0}:{1}:FTPApi.Upload): fullUrl = {2}", prevClassName, prevFuncName, targetUrl + "?" + reqParams + "&authToken=" + Global.authToken));

            try
            {
                // call
                WebClient wcClient = new WebClient();
                byte[] result = wcClient.UploadFile(targetUrl + "?" + reqParams + "&authToken=" + Global.authToken, "POST", filePath);

                // result
                resultJson = JObject.Parse(Encoding.UTF8.GetString(result));
                System.Diagnostics.Debug.WriteLine(string.Format("FTPLOG({0}:{1}:FTPApi.Upload): result = {2}", prevClassName, prevFuncName, resultJson["result"].ToString()));

                if (!resultJson["result"].ToString().Equals("success"))
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("FTPLOG({0}:{1}:FTPApi.Upload): msg = {2}", prevClassName, prevFuncName, resultJson["msg"].ToString()));
                    throw new Exception(resultJson["msg"].ToString());
                }

                return resultJson;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("FTPLOG({0}:{1}:FTPApi.Upload): ex = {2}", prevClassName, prevFuncName, ex.ToString()));
                throw new Exception(ex.Message);
               // return false;
            }
        }
    }
}

