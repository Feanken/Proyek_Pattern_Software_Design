using CrystalDecisions.Web;
using Proyek_Pattern_Software_Design.Controller;
using Proyek_Pattern_Software_Design.DataSet;
using Proyek_Pattern_Software_Design.Model;
using Proyek_Pattern_Software_Design.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Proyek_Pattern_Software_Design.View
{
    public partial class ReportPage : System.Web.UI.Page
    {
        TransactionController transactionController = new TransactionController();
        JewelController jewelController = new JewelController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null && Request.Cookies["Cookie"] == null)
            {
                Response.Redirect("~/View/Homepage.aspx");
            }

            HttpCookie cookie = Request.Cookies["Cookie"];
            if (cookie != null)
            {
                int userID = Convert.ToInt32(cookie.Value);
                UserController controller = new UserController();
                MsUser user = controller.getUserByID(userID);

                if (user != null)
                {
                    Session["User"] = user;
                    Session["Role"] = user.UserRole;
                }
            }
            var role = Session["Role"];
            if (role == null || role.ToString() != "Admin")
            {
                Response.Redirect("~/View/HomePage.aspx");
            }

            TransactionReport report = new TransactionReport();
            CrystalReportViewer1.ReportSource = report;
            TransactionDataSet data = getData(transactionController.getTransaction());
            report.SetDataSource(data);
        }

        private TransactionDataSet getData(List<Proyek_Pattern_Software_Design.Model.TransactionHeader> transactions)
        {
            TransactionDataSet dataSet = new TransactionDataSet();
            var headerTable = dataSet.TransactionHeader;
            var detailTable = dataSet.TransactionDetail;
            var jewelTable = dataSet.MsJewel;

            foreach (var t in transactions)
            {
                decimal totalTransaction = 0;

                // Tambah ke header
                var hrow = headerTable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["UserID"] = t.UserID;
                hrow["TransactionDate"] = t.TransactionDate;
                hrow["PaymentMethod"] = t.PaymentMethod;
                hrow["TransactionStatus"] = t.TransactionStatus;
                headerTable.Rows.Add(hrow);

                foreach (var d in t.TransactionDetails)
                {
                    var jewel = jewelController.getJewelByID(d.JewelID);
                    if (jewel == null) continue;

                    decimal price = Convert.ToDecimal(jewel.JewelPrice);
                    decimal subtotal = price * Convert.ToDecimal(d.Quantity);
                    totalTransaction += subtotal;

                    // Tambah ke detail
                    var drow = detailTable.NewRow();
                    drow["TransactionID"] = d.TransactionID;
                    drow["JewelID"] = d.JewelID;
                    drow["Quantity"] = d.Quantity;
                    drow["Price"] = price;
                    drow["Subtotal"] = subtotal;
                    detailTable.Rows.Add(drow);

                    // Tambah ke MsJewel jika belum ada
                    bool jewelExists = jewelTable.AsEnumerable()
                        .Any(row => Convert.ToInt32(row["JewelID"]) == jewel.JewelID);
                    if (!jewelExists)
                    {
                        var jrow = jewelTable.NewRow();
                        jrow["JewelID"] = jewel.JewelID;
                        jrow["BrandID"] = jewel.BrandID;
                        jrow["CategoryID"] = jewel.CategoryID;
                        jrow["JewelName"] = jewel.JewelName;
                        jrow["JewelPrice"] = jewel.JewelPrice;
                        jrow["JewelReleaseYear"] = jewel.JewelReleaseYear;
                        jewelTable.Rows.Add(jrow);
                    }
                }

                // Set Subtotal ke header terakhir (harus setelah loop detail)
                hrow["Subtotal"] = totalTransaction;
            }

            return dataSet;
        }

    }
}