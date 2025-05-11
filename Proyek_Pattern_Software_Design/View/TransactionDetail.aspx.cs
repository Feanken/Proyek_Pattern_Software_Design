using Proyek_Pattern_Software_Design.Controller;
using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyek_Pattern_Software_Design.View
{
	public partial class TransactionDetail : System.Web.UI.Page
	{
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
            int transactionId = Convert.ToInt32(Request.QueryString["id"]);
            TransactionController transactionController = new TransactionController();
            GV.DataSource = transactionController.getTransactionDetailByTransactionId(transactionId);
            GV.DataBind();
        }
        protected void Unnamed1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}