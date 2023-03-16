using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SourceMarket.App_Code
{
    public class ClassDeals
    {
        public string ID, SellerEmail, BuyerEmail, DealTime, SVisaID, BVisaID, ProductID;
        public ClassDeals() { }
        public static string add_deal(string SE, string BE, string DT, string SV, string BV, string P)
        {
            //insert the deal
            
            string SQL = "INSERT INTO [DEALS] ([SellerEmail], [BuyerEmail], [DealTime], [SVisaID], [BVisaID], [ProductID],[SourceID],[PPrice])";
            SQL = SQL + "VALUES ('{0}','{1}',#{2}#,'{3}','{4}','{5}','{6}','{7}')";
            SQL = string.Format(SQL, SE, BE, DT, SV, BV, P, ClassPRODUCTS.GetBY(P, "SourcePath"), ClassPRODUCTS.GetBY(P,"price"));
            
            Dbase.ChangeTable(SQL);
            
            string SQL1 = "SELECT * FROM [DEALS] WHERE [SellerEmail]='" + SE + "' AND [BuyerEmail]= '" + BE + "' AND  [DealTime]=#" + DT + "#";
            DataTable dt = Dbase.SelectFromTable(SQL1);
            return dt.Rows[0]["ID"].ToString();
            
        }
        public static string GetBy(string ID, string CN)
        {
            string SQL = "SELECT * FROM [DEALS] WHERE [ID]=" + ID + "";
            DataTable dt = Dbase.SelectFromTable(SQL);
            return dt.Rows[0][CN].ToString();

        }
        public static DataTable GetDealsFor(string Email)
        {
            return Dbase.SelectFromTable("SELECT * FROM [DEALS] WHERE [SellerEmail]='" + Email + "'");
        }
        public static DataTable GetDealsTo(string Email)
        {
            return Dbase.SelectFromTable("SELECT * FROM [DEALS] WHERE [BuyerEmail]='" + Email + "'");
        }

        public static bool isDealed(string Email ,string PID)
        {
            if (Dbase.SelectFromTable("SELECT * FROM [DEALS] WHERE [BuyerEmail]='" + Email + "' AND [ProductID]='" + PID+"'").Rows.Count == 0)
                return false;
            if (Dbase.SelectFromTable("SELECT * FROM [DEALS] WHERE [BuyerEmail]='" + Email + "' AND [ProductID]='" + PID + "' AND [SourceID]='" + ClassPRODUCTS.GetBY(PID, "SourcePath")+"'").Rows.Count == 0)
                return false;
            return true;
        }
    }
}