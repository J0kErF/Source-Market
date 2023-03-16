using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SourceMarket.App_Code
{
    public class ClassCart
    {
        string ID, UID, PID;
        public ClassCart() { }
        public static double GetTotal(string UID)
        {

            string myQuery = "SELECT Product.* FROM ((cartproducts INNER JOIN Product ON cartproducts.PID = Product.ID) INNER JOIN USERS ON cartproducts.UID = USERS.Email) WHERE (USERS.Email = '"+UID+"')";
            DataTable dt = Dbase.SelectFromTable(myQuery);
          
            double sum = 0;
            int i = dt.Rows.Count-1;
            while (i != -1)
            {
                sum += Convert.ToDouble(dt.Rows[i]["price"].ToString());
                i--;
            }
            return sum;
        }
        public static DataTable GetCarts()
        {
            string SQL = "SELECT * FROM [cartproducts]";
            DataTable dt = Dbase.SelectFromTable(SQL);
            return dt;
        }
        public static void AddToCart(string UID,string PID)
        {
            
                string SQL = "INSERT INTO [cartproducts] ([UID], [PID])";
                SQL = SQL + "VALUES ('{0}','{1}')";
                SQL = string.Format(SQL, UID,PID);
                Dbase.ChangeTable(SQL);
            
        }
        public static void Remove(string PID,string UID)
        {
            string myQuey = "DELETE * FROM [cartproducts] WHERE PID = " + Convert.ToInt32(PID) + " AND UID = '" + UID + "' ";
            Dbase.ChangeTable(myQuey);
        }
        public static bool isaddedtocart(string UID, string PID)
        {
            string SQL = "SELECT * FROM [cartproducts] WHERE [UID]='"+UID+"' AND [PID]="+PID;
            DataTable dt = Dbase.SelectFromTable(SQL);
            if (dt.Rows.Count == 0)
                return false;
            return true;
        }
    }
}