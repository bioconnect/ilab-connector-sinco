using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using System.Data;
using System.Reflection;
using System.Diagnostics;

namespace LSP.Common
{
    public class SQLiteHelper
    {
        //static string strConn = @"Data Source=C:\Users\inglo\Documents\workspaces\connector\sdms2.db";
        //static string strConn = @"Data Source=" + Application.StartupPath + @"\sdms.db";

        // sqlite select
        public static DataSet SelectDataSet(string sql)
        {
            // log출력: 이전 Class명, 함수명
            string prevClassName = new StackTrace().GetFrame(1).GetMethod().ReflectedType.Name;
            string prevFuncName = new StackFrame(1, true).GetMethod().Name;
            System.Diagnostics.Debug.WriteLine(string.Format("DBLOG({0}:{1}:SQLiteHelper:SelectDataSet): sql = {2}", prevClassName, prevFuncName, sql));

            using (SQLiteConnection conn = new SQLiteConnection(Global.dbConn))
            {
                conn.Open();
                SQLiteDataAdapter adpt = new SQLiteDataAdapter(sql, Global.dbConn);
                DataSet ds = new DataSet();
                adpt.Fill(ds);

                // 검색결과 여부 체크
                int count = ds.Tables[0].Rows.Count;
                if (count != 0)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("DBLOG(SQLiteHelper:SelectDataSet): Rows[0][0] = {0}", ds.Tables[0].Rows[0][0]));
                }
                return ds;
            }
        }

        // sqlite db 저장
        public static void SaveData(string sql)
        {
            // log출력: 이전 Class명, 함수명
            string prevClassName = new StackTrace().GetFrame(1).GetMethod().ReflectedType.Name;
            string prevFuncName = new StackFrame(1, true).GetMethod().Name;
            System.Diagnostics.Debug.WriteLine(string.Format("DBLOG({0}:{1}:SQLiteHelper.SaveData): sql = {2}", prevClassName, prevFuncName, sql));

            using (SQLiteConnection conn = new SQLiteConnection(Global.dbConn))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                int iResult = cmd.ExecuteNonQuery();

                System.Diagnostics.Debug.WriteLine(string.Format("DBLOG({0}:{1}:SQLiteHelper.SaveData): iResult = {2}", prevClassName, prevFuncName, iResult));
            }
        }
    }
}
