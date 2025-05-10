using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyek_Pattern_Software_Design.View
{
	public partial class HandleOrder : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            var orders = transactionController.getUnfinishedTransactions();
            GVOrders.DataSource = orders;
            GVOrders.DataBind();
        }

        protected string GetActionText(string status)
        {
            switch (status)
            {
                case "Payment Pending": return "Confirm Payment";
                case "Shipment Pending": return "Ship Package";
                case "Arrived": return "Waiting for user confirmation...";
                default: return "";
            }
        }

        protected bool GetActionEnabled(string status)
        {
            return status != "Arrived";
        }
    }
}