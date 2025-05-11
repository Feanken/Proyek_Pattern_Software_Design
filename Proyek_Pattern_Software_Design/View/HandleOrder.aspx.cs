using Proyek_Pattern_Software_Design.Controller;
using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData.ModelProviders;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyek_Pattern_Software_Design.View
{
	public partial class HandleOrder : System.Web.UI.Page
	{
        TransactionController transactionController = new TransactionController();
        UserController controller = new UserController();
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
                MsUser user = controller.getUserByID(userID);
                if (user != null)
                {
                    Session["User"] = user;
                    Session["Role"] = user.UserRole;
                }
            }
            if(Session["Role"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
            string eventTarget = Request["__EVENTTARGET"];
            string eventArgument = Request["__EVENTARGUMENT"];

            if (eventTarget == "UpdateStatus")
            {
                string[] args = eventArgument.Split(',');
                int transactionID = int.Parse(args[0]);
                string newStatus = args[1];

                bool updated = transactionController.UpdateTransactionStatus(transactionID, newStatus);
                LabelMessage.Text = updated ? "Status updated." : "Failed to update.";
                LoadOrders();
            }

            if (!IsPostBack)
            {
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            List<TransactionHeader> orders = transactionController.getAllTransactions();
            GridOrders.DataSource = orders;
            GridOrders.DataBind();
        }
        protected override void RaisePostBackEvent(IPostBackEventHandler sourceControl, string eventArgument)
        {
            base.RaisePostBackEvent(sourceControl, eventArgument);
        }

        protected void GridOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateStatus")
            {
                string[] args = e.CommandArgument.ToString().Split(',');
                int transactionID = int.Parse(args[0]);
                string newStatus = args[1];

                bool updated = transactionController.UpdateTransactionStatus(transactionID, newStatus);
                LabelMessage.Text = updated ? "Status updated." : "Failed to update.";
                LoadOrders();
            }
        }

        protected void GridOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var data = (TransactionHeader)e.Row.DataItem;

                var btnAction = (Button)e.Row.FindControl("btnAction");
                var lblWaiting = (Label)e.Row.FindControl("lblWaiting");

                if (data.TransactionStatus == "Payment Pending")
                {
                    btnAction.Text = "Confirm Payment";
                    btnAction.CommandArgument = $"{data.TransactionID},Shipment Pending";
                }
                else if (data.TransactionStatus == "Shipment Pending")
                {
                    btnAction.Text = "Ship Package";
                    btnAction.CommandArgument = $"{data.TransactionID},Arrived";
                }
                else if (data.TransactionStatus == "Arrived")
                {
                    btnAction.Visible = false;
                    lblWaiting.Visible = true;
                }
                else
                {
                    btnAction.Visible = false;
                }
            }
        }

    }
}