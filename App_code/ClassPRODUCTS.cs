using System.Data;

namespace SourceMarket.App_Code
{
    public class ClassPRODUCTS
    {
        public string ID, Pic, title, price, info, description, specifications, OS, category, codelang, Email, state, addeddate, downloadcount , SourcePath;
        public ClassPRODUCTS() { }
        public ClassPRODUCTS(string ID, string Pic, string title, string price, string info, string description, string specifications, string OS, string category, string codelang, string Email, string state, string addeddate, string downloadcount ,string SourcePath)

        {
            this.ID = ID;
            this.Pic = Pic;
            this.title = title;
            this.price = price;
            this.info = info;
            this.description = description;
            this.specifications = specifications;
            this.OS = OS;
            this.codelang = codelang;
            this.category = category;
            this.Email = Email;
            this.state = state;
            this.addeddate = addeddate;
            this.downloadcount = downloadcount;
            this.SourcePath = SourcePath;
        }
        public static DataTable GetMyProducts(string Email)
        {
            return Dbase.SelectFromTable("SELECT * FROM [Product] WHERE [Email] = '" + Email + "'");
        }
        public static DataTable GetProducts()
        {
            string myQuery = "SELECT * FROM [Product]";
            DataTable dt = Dbase.SelectFromTable(myQuery);
            return dt;
        }
        public static ClassPRODUCTS GetProduct(string ID)
        {
            string myQuery = "SELECT * FROM [Product] WHERE [ID]=" + ID + "";
            DataTable dt = Dbase.SelectFromTable(myQuery);
            if (dt.Rows.Count == 0)
                return null;
            return new ClassPRODUCTS(ID, dt.Rows[0]["Pic"].ToString(), dt.Rows[0]["title"].ToString(), dt.Rows[0]["price"].ToString(), dt.Rows[0]["info"].ToString(), dt.Rows[0]["description"].ToString(), dt.Rows[0]["specifications"].ToString(), dt.Rows[0]["OS"].ToString(), dt.Rows[0]["category"].ToString(), dt.Rows[0]["codelang"].ToString(), dt.Rows[0]["Email"].ToString(), dt.Rows[0]["state"].ToString(), dt.Rows[0]["addeddate"].ToString(), dt.Rows[0]["downloadcount"].ToString(),dt.Rows[0]["SourcePath"].ToString());
        }
        public static string GetBY(string ID, string CN)
        {
            string myQuery = "SELECT * FROM [Product] WHERE [ID] = " + ID + "";
            DataTable dt = Dbase.SelectFromTable(myQuery);
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows[0][CN].ToString();
        }
        public static void Insert( string Pic, string title, string price, string info, string description, string specifications, string OS, string category, string codelang, string Email, string state, string addeddate, string downloadcount, string SourcePath)
        {
            string SQL = "INSERT INTO [Product] ( [Pic], [title], [price], [info], [description], [specifications], [OS], [category], [codelang], [Email], [state], [addeddate], [downloadcount], [SourcePath])";
            SQL = SQL + "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',#{11}#,{12},{13})";
            SQL = string.Format(SQL, Pic, title, price, info, description, specifications, OS, category, codelang, Email, state, addeddate, downloadcount, SourcePath);
            Dbase.ChangeTable(SQL);
        }
        public static void Update(string ID, string Pic, string title, string price, string info, string description, string specifications, string OS, string category, string codelang,  string state, string SourcePath)
        {
            string SQL = "UPDATE [Product] SET [Pic]= '{1}' ,[title]= '{2}' ,[price]= '{3}' ,[info]= '{4}' ,[description]= '{5}' ,[specifications]= '{6}' ,[OS]= '{7}' ,[category]= '{8}' ,[codelang]= '{9}', [state]= '{10}' ,[SourcePath]={11} ";
            SQL += " WHERE [ID]= {0}";
            SQL = string.Format(SQL, ID, Pic, title, price, info, description, specifications, OS, category, codelang,state, SourcePath);
            Dbase.ChangeTable(SQL);
        }
        public static void edit(string ID, string val, string CN)
        {
            string SQL = "UPDATE [Product] SET [" + CN + "] = '" + val + "' WHERE [ID]= " + ID + "";
            Dbase.ChangeTable(SQL);
        }
        public static void delete(string ID)
        {
            string SQL = "DELETE * FROM [Product] WHERE [ID]= " + ID + "";
            Dbase.ChangeTable(SQL);
        }
        public static string GetSpecificationsAsHTML(string ID)
        {
            string myQuery = "Select * from [Product] Where [ID]=" + ID + "";
            System.Data.DataTable dt = Dbase.SelectFromTable(myQuery);
            string HTMLTable = "<tr><td class=\"stat\"> OS </td><td>" + dt.Rows[0]["OS"].ToString() + "</td></tr>";
            HTMLTable += "<tr><td class=\"stat\"> Code Language </td><td>" + dt.Rows[0]["codelang"].ToString() + "</td></tr>";
            HTMLTable += "<tr><td class=\"stat\"> Category </td><td>" + dt.Rows[0]["category"].ToString() + "</td></tr>";
            if (dt.Rows.Count == 0)
                return HTMLTable += "<tr><td colspan=2> no Specification more found </td><td></tr>";
            
            HTMLTable += dt.Rows[0]["specifications"].ToString();

            /* OLD DATA FORMAT
             * string Specifications = dt.Rows[0]["specifications"].ToString(); int start = 0;
             * for (int i = 0; i < Specifications.Length; i++)
             * {
             *     if (Specifications[i] == '?')
             *     {
             *          HTMLTable += "<tr><td class=\"stat\">" + Specifications.Substring(start, i) + "</td>";
             *          start = i+1;
             *     }
             *     if (Specifications[i] == '!')
             *     {
             *          HTMLTable += "<td>" + Specifications.Substring(start, i-start ) + "</td></tr>";
             *          start = i+1;
             *     }
             *
             * }
             */
            return HTMLTable;
        }
    }
}