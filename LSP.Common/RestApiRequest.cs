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
    public class RestApiRequest
    {
        public static JObject CallAsyncWithResult(JObject reqParams, string targetUrl)
        {
            // authtoken 붙이기
            reqParams.Add("authToken", Global.authToken);
            if (!reqParams.ContainsKey("regId"))
                reqParams.Add("regId", Global.userPk);


            // log출력: 이전 Class명, 함수명
            string prevClassName = new StackTrace().GetFrame(1).GetMethod().ReflectedType.Name;
            string prevFuncName = new StackFrame(1, true).GetMethod().Name;
            System.Diagnostics.Debug.WriteLine(string.Format("APILOG({0}:{1}:CallAsync.Call): targetUrl = {2}", prevClassName, prevFuncName, targetUrl));
            System.Diagnostics.Debug.WriteLine(string.Format("APILOG({0}:{1}:CallAsync.Call): reqParams = {2}", prevClassName, prevFuncName, reqParams.ToString()));

            JObject resultJson = Call(reqParams, targetUrl, prevClassName, prevFuncName);

            return resultJson;
        }

        public static void CallAsync(JObject reqParams, string targetUrl)
        {
            // authtoken 붙이기
            reqParams.Add("authToken", Global.authToken);
            if (!reqParams.ContainsKey("regId"))
                reqParams.Add("regId", Global.userPk);

            // log출력: 이전 Class명, 함수명
            string prevClassName = new StackTrace().GetFrame(1).GetMethod().ReflectedType.Name;
            string prevFuncName = new StackFrame(1, true).GetMethod().Name;
            System.Diagnostics.Debug.WriteLine(string.Format("APILOG({0}:{1}:CallAsync.Call): targetUrl = {2}", prevClassName, prevFuncName, targetUrl));
            System.Diagnostics.Debug.WriteLine(string.Format("APILOG({0}:{1}:CallAsync.Call): reqParams = {2}", prevClassName, prevFuncName, reqParams.ToString()));

            Call(reqParams, targetUrl, prevClassName, prevFuncName);
        }

        public static JObject CallSync(JObject reqParams, string targetUrl)
        {
            // authtoken 붙이기
            reqParams.Add("authToken", Global.authToken);
            if (!reqParams.ContainsKey("regId"))
                reqParams.Add("regId", Global.userPk);

            // log출력: 이전 Class명, 함수명
            string prevClassName = new StackTrace().GetFrame(1).GetMethod().ReflectedType.Name;
            string prevFuncName = new StackFrame(1, true).GetMethod().Name;
            System.Diagnostics.Debug.WriteLine(string.Format("APILOG({0}:{1}:CallSync.Call): targetUrl = {2}", prevClassName, prevFuncName, targetUrl));
            System.Diagnostics.Debug.WriteLine(string.Format("APILOG({0}:{1}:CallSync.Call): reqParams = {2}", prevClassName, prevFuncName, reqParams.ToString()));

            JObject resultJson = null;
            try
            {
                resultJson = Call(reqParams, targetUrl, prevClassName, prevFuncName);

                if (!resultJson["result"].ToString().Equals("success"))
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("APILOG({0}:{1}:CallSync.Call): result = {2}", prevClassName, prevFuncName, resultJson["result"].ToString()));
                    throw new Exception(resultJson["msg"].ToString());
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("APILOG({0}:{1}:CallSync.Call): Exception = {2}", prevClassName, prevFuncName, ex.ToString()));
                throw new Exception(ex.Message);
            }

            return resultJson;
        }

        public static JObject Call(JObject reqParams, string targetUrl, string prevClassName, string prevFuncName)
        {
            // request json param
            byte[] contentBytes = Encoding.UTF8.GetBytes(reqParams.ToString());

            // request
            WebRequest request = WebRequest.Create(targetUrl);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = contentBytes.Length;

            // write
            Stream st = request.GetRequestStream();
            st.Write(contentBytes, 0, contentBytes.Length);
            st.Close();

            // response
            JObject resultJson = null;
            using (WebResponse response = request.GetResponse())
            using (Stream dataStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(dataStream))
            {
                string result = reader.ReadToEnd();
                System.Diagnostics.Debug.WriteLine(string.Format("APILOG({0}:{1}:RestApiRequest.Call): result = {2}", prevClassName, prevFuncName, result));
                resultJson = JObject.Parse(result);
            }

            return resultJson;
        }
    }
}