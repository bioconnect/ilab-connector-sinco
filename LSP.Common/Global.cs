using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP.Common
{
    public class Global
    {
        // 기본정보
        public static string comCd;
        public static string plantCd;
        public static string userPk;
        public static string userId;
        public static string passwd;
        public static string authToken;
        public static string deptNm;    // 부서명 // 서버 로그인시 아직 안 가져와서 일단 패스
        public static string teamNm;    // 팀명
        public static string userNm;    // 사용자명
        public static string lang;    // 사용자명
        public static string useYn;


        // FTP 정보
        public static string ftpIP;
        public static string ftpID;
        public static string ftpPWD;

        // 클라이언트 정보
        public static string clientSeq;
        public static string clientID;
        public static string clientWatchFolder;
        public static string folderAutoYn;
        public static string clientIP;    // 컴퓨터 아이피;

        // 기타
        public static string loginYn = "N";   // 로그인 여부
        public static string svrUrl;    // rest api 호출 서버 url

        // DB위치
        public static string dbConn;

        // 다국어
        private static Dictionary<string, string> _multiLang = new Dictionary<string, string>();

        public static void ResetMultiLang()
        {
            _multiLang.Clear();
        }

        public static void SetMultiLang(string key, string value)
        {
            if (_multiLang.ContainsKey(key))
            {
                _multiLang[key] = value;
            }
            else
            {
                _multiLang.Add(key, value);
            }
        }

        public static string GetMultiLang(string key, string comment)
        {
            string result = null;

            if (_multiLang.ContainsKey(key))
            {
                result = _multiLang[key];
            } else
            {
                result = "*" + comment;
            }

            return result;
        }

        public static string GetMultiLang(string key, string param, string comment)
        {
            string result = null;

            if (_multiLang.ContainsKey(key))
            {
                result = "*" + string.Format(_multiLang[key], param);
            }
            else
            {
                result = comment;
            }

            return result;
        }


        public Global()
        {
        }
    }
}
