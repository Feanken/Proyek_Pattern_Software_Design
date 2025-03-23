using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyek_Pattern_Software_Design.Master
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MsUser"] == null)
            {
                ButtonRegister.Visible = true;
                ButtonLogin.Visible = true;
                ButtonCart.Visible = false;
                ButtonMyOrders.Visible = false;
                ButtonProfile.Visible = false;
                ButtonAddJewel.Visible = false;
                ButtonLogOut.Visible = false;
                ButtonAddJewel.Visible = false;
                ButtonReports.Visible = false;
                ButtonHandleOrders.Visible = false;
            }
            else
            {
                ButtonRegister.Visible = false;
                ButtonLogin.Visible = false;
                ButtonCart.Visible = true;
                ButtonMyOrders.Visible = true;
                ButtonProfile.Visible = true;
                ButtonAddJewel.Visible = false;
                ButtonLogOut.Visible = true;
                ButtonAddJewel.Visible = false;
                ButtonReports.Visible = false;
                ButtonHandleOrders.Visible = false;
            }
        }

        protected void ButtonHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HomePage.aspx");
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/LoginPage.aspx");
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/RegisterPage.aspx");
        }

        protected void ButtonCart_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonMyOrders_Click1(object sender, EventArgs e)
        {

        }

        protected void ButtonProfile_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session.Remove("MsUser");
            HttpCookie cookie = Request.Cookies["MsUser_Cookie"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-2);
                Response.Cookies.Add(cookie);
            }
            Response.Redirect("~/View/HomePage.aspx");
        }

        protected void ButtonAddJewel_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonReports_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonHandleOrders_Click(object sender, EventArgs e)
        {

        }
    }
}