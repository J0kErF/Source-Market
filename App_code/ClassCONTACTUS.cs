using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace SourceMarket.App_Code
{
    public class ClassCONTACTUS
    {
        public string ID, FullName, Subject, Email, Message;
        DateTime Senddate;
        public ClassCONTACTUS() { }
        public ClassCONTACTUS(string ID, string FullName, string Subject, string Email, string Message, DateTime Senddate)
        {
            this.ID = ID;
            this.FullName = FullName;
            this.Subject = Subject;
            this.Email = Email;
            this.Message = Message;
            this.Senddate = Senddate;
        }
        public static DataTable GetContactus()
        {
            string SQL = "SELECT * FROM [contactus]";
            DataTable dt = Dbase.SelectFromTable(SQL);
            return dt;
        }
        public static void Insert( string FullName, string Subject, string Email, string Message, string Senddate)
        {
            string SQL = "INSERT INTO [contactus] ([FullName], [Subject], [Email], [Message], [Sendeddate])";
            SQL = SQL + "VALUES ('{0}','{1}','{2}','{3}',#{4}#)";
            SQL = string.Format(SQL, FullName, Subject, Email, Message, Senddate);
            Dbase.ChangeTable(SQL);
        }
    }
}