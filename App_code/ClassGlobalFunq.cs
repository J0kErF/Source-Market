using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SourceMarket.App_Code
{
    public class ClassGlobalFunq
    {
        public static double GetEarnings(string Email)
        {
            double Earnings = 0;
            DataTable dt = ClassDeals.GetDealsFor(Email);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Earnings += Convert.ToDouble(dt.Rows[i]["PPrice"].ToString());
            }
            return Earnings;
        }
        public static int statusnotificationscount(string email, string status)
        {
            string SQL = "SELECT * FROM [alerts] WHERE [To]='" + email + "' AND [status]='" + status + "'";
            DataTable dt = Dbase.SelectFromTable(SQL);
            return dt.Rows.Count;
        }
        public static string HTMLnotificationMIN(string Email)
        {
            string HTMLTABLE = "";
            DataTable dt = ClassAlerts.GetNotificationalerts(Email);
            if (dt == null)
                return HTMLTABLE;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HTMLTABLE += "<a class=\"d-flex align-items-center dropdown-item\" href=\"alerts.aspx?ID=" + dt.Rows[i]["ID"].ToString() + "\">";
                HTMLTABLE += "<div class=\"dropdown-list-image mr-3\">";
                HTMLTABLE += "<img class=\"rounded-circle\" src=\"assets/img/avatars/avatar.png\">";
                HTMLTABLE += "</div>";
                HTMLTABLE += "<div class=\"font-weight-bold\">";
                HTMLTABLE += "<div class=\"text-truncate\"><span>" + dt.Rows[i]["title"].ToString() + "</span></div>";
                HTMLTABLE += "<p class=\"small text-gray-500 mb-0\">" + dt.Rows[i]["From"].ToString() + " - " + dt.Rows[i]["alerttime"].ToString() + "</p>";
                HTMLTABLE += "</div>";
                HTMLTABLE += "</a>";
            }
            return HTMLTABLE;
        }
        public static string get_Deals_as_html_table(List<string> vs)
        {
            string HTMLTABLE = "<center><table border=1><tr><td>ID</td><td>Seller Email</td><td>Seller Visa</td><td>Product Link</td><td>Product Name</td><td>Price</td><td>Information</td><td>Ver.</td><td>Download Link</td></tr>";
            foreach (var item in vs)
            {
                HTMLTABLE += "<tr><td>&nbsp;" + item + "</td>";//add the ID
                HTMLTABLE += "<td>&nbsp;" + ClassDeals.GetBy(item, "SellerEmail") + "</td>";//add the SellerEmail
                HTMLTABLE += "<td>&nbsp;" + ClassDeals.GetBy(item, "SVisaID") + "</td>";//add the SVisaID
                HTMLTABLE += "<td>&nbsp;" + ClassDeals.GetBy(item, "ProductID") + "</td>";//add the ProductID
                HTMLTABLE += "<td>&nbsp;" + ClassPRODUCTS.GetBY(ClassDeals.GetBy(item, "ProductID"), "title") + "</td>";//add the title
                HTMLTABLE += "<td>&nbsp;" + ClassPRODUCTS.GetBY(ClassDeals.GetBy(item, "ProductID"), "price") + "</td>";//add the price
                HTMLTABLE += "<td>&nbsp;" + ClassPRODUCTS.GetBY(ClassDeals.GetBy(item, "ProductID"), "info") + "</td>";//add the info
                HTMLTABLE += "<td>&nbsp;" + ClassSources.GetBy(ClassDeals.GetBy(item, "SourceID"), "version") + "</td>";//add the version
                HTMLTABLE += "<td>&nbsp;" + ClassSources.GetBy(ClassDeals.GetBy(item, "SourceID"), "FilePath") + "</td></tr>";//add the FilePath
            }

            return HTMLTABLE + "</table></center>";
        }
        public static string create_invoice_HTMLTABLE(List<string> vs, string Email)
        {

            string HTMLTABLE = "<table align=center border=1>";//openning the table
            //the header
            HTMLTABLE += "<tr>";//openning new row
            HTMLTABLE += "<td style=\"height: 77px\">";//openning new cell
            //header data
            HTMLTABLE += "<table style=\"height: 80px\">";//openning new table to organize the data
            HTMLTABLE += "<tr>";//openning new row
            HTMLTABLE += "<td class=\"text-left\" style=\"width: 609px\">";//openning new cell
            HTMLTABLE += "<span style=\"font-size: large\">";//openning new span
            HTMLTABLE += "Invoice : ";//span text
            HTMLTABLE += "</span>";//closing span
            HTMLTABLE += generateID("Invoices");//adding label to show the data from Database
            HTMLTABLE += "</td>";//closing the cell
            HTMLTABLE += "<td class=\"text-right\">";//openning new cell
            HTMLTABLE += "&nbsp;&nbsp;&nbsp; " + DateTime.Now.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ";//adding timelabel to show the time invoice created
            HTMLTABLE += "</td>";//closing the cell
            HTMLTABLE += "</tr>";//closing the row
            HTMLTABLE += "</table>";//closing the table
            //header data end
            HTMLTABLE += "</td>";//closing the cell
            HTMLTABLE += "</tr>";//closing the row
            //header end
            /********************************************/
            //the body
            // USER data
            HTMLTABLE += "<tr>";//openning new row
            HTMLTABLE += "<td style=\"font-size: medium;\">";//openning new cell
            HTMLTABLE += "<strong>USER: <br /><br /></strong>";//title
            HTMLTABLE += "<table>";//openning new table to organize the data
            HTMLTABLE += "<tr>";//openning new row
            HTMLTABLE += "<td style=\"width: 599px\">";//openning new cell
            HTMLTABLE += "Email : ";//title
            HTMLTABLE += Email;//adding label to show the data from Database
            HTMLTABLE += "<br /><br />";//organize
            HTMLTABLE += "Name : ";//title
            HTMLTABLE += ClassUSERS.GetBY(Email, "FullName");//adding label to show the data from Database
            HTMLTABLE += "<br /><br />";//organize
            HTMLTABLE += "Phone : ";//title
            HTMLTABLE += ClassUSERS.GetBY(Email, "PhoneNumber");//adding label to show the data from Database
            HTMLTABLE += "<br />";//organize
            HTMLTABLE += "</td>";//closing the cell
            HTMLTABLE += "<td>";//openning the cell
            HTMLTABLE += "Status : ";//title
            HTMLTABLE += ClassUSERS.GetBY(Email, "status");//adding label to show the data from Database
            HTMLTABLE += "<br /><br />";//organize
            HTMLTABLE += "Join Date : ";//title
            HTMLTABLE += ClassUSERS.GetBY(Email, "joindate");//adding label to show the data from Database
            HTMLTABLE += "<br /><br /><br />";//organize
            HTMLTABLE += "</td>";//closing the cell
            HTMLTABLE += "</tr>";//closing the row
            HTMLTABLE += "</table>";//closing the table
            //USER data end
            HTMLTABLE += "</td>";//closing the cell
            HTMLTABLE += "</tr>";//closing the row
            //Credit Card data
            HTMLTABLE += "<tr>";//openning new row
            HTMLTABLE += "<td style=\"font-size: medium;\">";//openning new cell
            HTMLTABLE += "<strong>Credit Card : <br /><br /></strong>";//title
            HTMLTABLE += "<table>";//openning new table to organize the data
            HTMLTABLE += "<tr>";//openning new row
            HTMLTABLE += "<td style=\"width: 599px\">";//openning new cell
            HTMLTABLE += "Credit Card : ";//title
            HTMLTABLE += Classvisas.GetDefault(Email).num;//adding label to show the data from Database
            HTMLTABLE += "<br /><br />";//organize
            HTMLTABLE += "Holder Name : ";//title
            HTMLTABLE += Classvisas.GetDefault(Email).HName;//adding label to show the data from Database
            HTMLTABLE += "</td>";//closing the cell
            HTMLTABLE += "<td>";//openning the cell
            HTMLTABLE += "Status : ";//title
            HTMLTABLE += Classvisas.GetDefault(Email).status;//adding label to show the data from Database
            HTMLTABLE += "<br /><br />";//organize
            HTMLTABLE += "This Is The Default CreditCard ";//title
            HTMLTABLE += "</td>";//closing the cell
            HTMLTABLE += "</tr>";//closing the row
            HTMLTABLE += "</table>";//closing the table
            //Credit Card data end
            HTMLTABLE += "</td>";//closing the cell
            HTMLTABLE += "</tr>";//closing the row
            //Deals data
            HTMLTABLE += "<tr>";//openning new row
            HTMLTABLE += "<td style=\"font-size: medium;\">";//openning new cell
            HTMLTABLE += "<strong>Deals : <br /><br /></strong>";//title
            HTMLTABLE += get_Deals_as_html_table(vs);
            HTMLTABLE += "<br /><br />";//organize
            HTMLTABLE += "</tr>";//closing the row
            //Deals data end
            //end of body
            HTMLTABLE += "</table>";//closing the table
            return HTMLTABLE;
        }
        public static int generateID(string table)
        {
            string SQL = "SELECT * FROM [" + table + "]";
            DataTable dataTable = Dbase.SelectFromTable(SQL);
            string ID = "-1";
            if (dataTable.Rows.Count != 0)
             ID = dataTable.Rows[dataTable.Rows.Count - 1]["ID"].ToString();
            return Convert.ToInt32(ID) + 1;
        }
        public static string GetHtmlTableFrom(DataTable dt)
        {
            string HtmlTable = "<table class=\"table dataTable my-0\" id=\"dataTable\">";
            //     CREATE THE HEAD
            HtmlTable += "<thead><tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                HtmlTable += "<th>";
                HtmlTable += dt.Columns[i].ColumnName;
                HtmlTable += "</th>";
            }
            HtmlTable += "<th>";
            HtmlTable += "Edit";
            HtmlTable += "</th>";
            HtmlTable += "<th>";
            HtmlTable += "Delete";
            HtmlTable += "</th>";

            HtmlTable += "</tr></thead>";
            //     CREATE THE BODY
            HtmlTable += "<tbody>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HtmlTable += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    HtmlTable += "<td>";
                    HtmlTable += dt.Rows[i][j];
                    HtmlTable += "</td>";
                }
                HtmlTable += "<td>";
                HtmlTable += "<a class=\"btn btn-primary\" role=\"button\" type=button><i class=\"fa fa-edit\"></i></button>";
                HtmlTable += "</td>";
                HtmlTable += "</tr>";
            }
            HtmlTable += "</tbody></table>";
            return HtmlTable;
        }
        public static DataTable GetDataWithcustomsql(string sql)
        {
            return Dbase.SelectFromTable(sql);
        }
        public static void IUDataWithcustomsql(string sql)
        {
            Dbase.ChangeTable(sql);
        }
        public static string GetAlert(string alertbody)
        {
            string message = alertbody;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            return sb.ToString();
        }

    }
}