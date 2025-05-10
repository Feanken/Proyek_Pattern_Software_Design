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

            ReportTransaction report = new ReportTransaction();
            CrystalReportViewer1.ReportSource = report;
            DataSet1 data = getData(transactionController.getTransaction());
            report.SetDataSource(data);
        }

        private DataSet1 getData(List<TransactionHeader> transactions)
        {
            DataSet1 dataSet = new DataSet1();
            var headerTable = dataSet.TransactionHeader;
            var detailTable = dataSet.TransactionDetail;

            foreach (TransactionHeader t in transactions)
            {
                var hrow = headerTable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["UserID"] = t.UserID;
                hrow["TransactionDate"] = t.TransactionDate;
                hrow["TransactionStatus"] = t.TransactionStatus;
                hrow["PaymentMethod"] = t.PaymentMethod;
                headerTable.Rows.Add(hrow);

                foreach (TransactionDetail d in t.TransactionDetails)
                {
                    var drow = detailTable.NewRow();
                    drow["TransactionID"] = d.TransactionID;
                    drow["JewelID"] = d.JewelID;
                    drow["Quantity"] = d.Quantity;
                    MsJewel jewel = jewelController.getJewelByID(d.JewelID);
                    decimal price = Convert.ToDecimal(jewel.JewelPrice);
                    decimal subtotal = price * Convert.ToDecimal(d.Quantity);

                    drow["Price"] = price;
                    drow["Subtotal"] = subtotal;
                    detailTable.Rows.Add(drow);
                }
            }
            return dataSet;
        }
    }
}