using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SourceMarket.App_Code
{
    public class ClassSources
    {
        public ClassSources() { }
        public static string GetBy(string ID, string CN)
        {
            string SQL = "SELECT * FROM [Sources] WHERE [ID]=" + ID + "";
            DataTable dt = Dbase.SelectFromTable(SQL);
            if (dt != null && dt.Rows.Count>0)
                return dt.Rows[0][CN].ToString();
            return null;
        }
        public static void AddSource(string Email, string AddDate, string FileName, string FileSize, string FilePath, string version, string ProductID)
        {
            string SQL = "INSERT INTO [Sources] ([Email], [AddDate], [FileName], [FileSize], [FilePath], [version], [ProductID])";
            SQL = SQL + "VALUES ('{0}',#{1}#,'{2}','{3}','{4}','{5}','{6}')";
            SQL = string.Format(SQL, Email, AddDate, FileName, FileSize, FilePath, version, ProductID);
            Dbase.ChangeTable(SQL);
        }
    }
}