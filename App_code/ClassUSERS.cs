using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SourceMarket.App_Code
{
    public class ClassUSERS
    {
        public string email, fullname, phonenumber, password, status, joindate;
        public ClassUSERS() { }
        public ClassUSERS(string email, string fullname, string phonenumber, string password, string status, string joindate)
        {
            this.email = email;
            this.fullname = fullname;
            this.status = status;
            this.password = password;
            this.status = status;
            this.joindate = joindate;
            this.phonenumber = phonenumber;
            
        }
        public static ClassUSERS GetUser(string Email)
        {
            string myQuery = "SELECT * FROM [USERS] WHERE [Email]='" + Email + "'";
            DataTable dt = Dbase.SelectFromTable(myQuery);
            if (dt.Rows.Count == 0)
                return null;
            return new ClassUSERS(Email, dt.Rows[0]["FullName"].ToString(), dt.Rows[0]["PhoneNumber"].ToString(), dt.Rows[0]["Password"].ToString(), dt.Rows[0]["status"].ToString(), dt.Rows[0]["joindate"].ToString());
        }
        public static DataTable GetUsers()
        {
            string myQuery = "SELECT * FROM [USERS]";
            DataTable dt = Dbase.SelectFromTable(myQuery);
            return dt;
        }
        public static string GetBY(string Email, string CN)
        {
            string myQuery = "SELECT * FROM [USERS] WHERE [Email] = '" + Email + "'";
            DataTable dt = Dbase.SelectFromTable(myQuery);
            if (dt.Rows.Count == 0)
                return null;
            if (dt.Rows[0][CN].ToString() == null || dt.Rows[0][CN].ToString() == "")
                return "";
            return dt.Rows[0][CN].ToString();
        }
        public static void Insert(string email, string fullname, string phonenumber, string password, string status, string joindate)
        {
            string SQL = "INSERT INTO [USERS] ([Email], [FullName], [status], [Password], [joindate], [PhoneNumber])";
            SQL = SQL + "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')";
            SQL = string.Format(SQL, email,fullname,status,password,joindate,phonenumber);
            Dbase.ChangeTable(SQL);
        }
        public static void Update(string email, string fullname, string phonenumber, string password, string status, string joindate)
        {
            string SQL = "UPDATE [USERS] SET [FullName]= '{1}', [status] = '{2}', [password] = '{3}', [joindate] = '{4}', [PhoneNumber] = '{5}'";
            SQL += " WHERE [Email]= '{0}'";
            SQL = string.Format(SQL, email, fullname, status, password, joindate, phonenumber);
            Dbase.ChangeTable(SQL);
        }
        public static void edit(string em, string val, string CN)
        {
            string SQL = "UPDATE [USERS] SET [" + CN + "] = '" + val + "' WHERE [Email]= '" + em + "'";
            Dbase.ChangeTable(SQL);
        }
        public static bool DoesEmailExist(string email)
        {
            string SQL = "SELECT * FROM [USERS] WHERE [Email]= '" + email + "'";
            System.Data.DataTable dt = Dbase.SelectFromTable(SQL);
            return dt.Rows.Count > 0;
        }
        

    }
}