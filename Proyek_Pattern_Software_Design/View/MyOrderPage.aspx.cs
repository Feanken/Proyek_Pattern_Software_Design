using Proyek_Pattern_Software_Design.Controller;
using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyek_Pattern_Software_Design.View
{
    public partial class MyOrderPage : System.Web.UI.Page
    {
        TransactionController transactionController = new TransactionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                if (role == null || role.ToString() != "Customer")
                {
                    Response.Redirect("~/View/HomePage.aspx");
                }
                loadData();
            }
        }

        public void loadData()
        {
            MsUser userlogin = (MsUser)Session["User"];
            GridView1.DataSource = transactionController.getTransactionByUserId(userlogin.UserID);
            GridView1.DataBind();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int transactionId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "ViewDetails")
            {
                Response.Redirect($"TransactionDetail.aspx?id={transactionId}");
            }
            else if (e.CommandName == "Confirm")
            {
                transactionController.UpdateTransactionStatus(transactionId, "Done");
                loadData();
            }
            else if (e.CommandName == "Reject")
            {
                transactionController.UpdateTransactionStatus(transactionId, "Rejected");
                loadData();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TransactionHeader transaction = (TransactionHeader)e.Row.DataItem;

                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                if (lblStatus != null)
                {
                    lblStatus.Text = transaction.TransactionStatus;
                }

                Button btnConfirm = (Button)e.Row.FindControl("btnConfirm");
                Button btnReject = (Button)e.Row.FindControl("btnReject");

                if (transaction.TransactionStatus == "Arrived")
                {
                    if (btnConfirm != null) btnConfirm.Visible = true;
                    if (btnReject != null) btnReject.Visible = true;
                }
                else
                {
                    if (btnConfirm != null) btnConfirm.Visible = false;
                    if (btnReject != null) btnReject.Visible = false;
                }
            }
        }
    
    }
}