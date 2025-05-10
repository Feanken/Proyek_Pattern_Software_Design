using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyek_Pattern_Software_Design.Master
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            setButtonVisibility();
            if (Session["User"] == null)
            {
                ButtonHome.Visible = true;
                ButtonLogin.Visible = true;
                ButtonRegister.Visible = true;
            }
            else if (Session["User"] != null && Session["Role"].ToString() == "Customer")
            {
               ButtonHome.Visible = true;
               ButtonCart.Visible = true;
               ButtonMyOrders.Visible = true;
               ButtonProfile.Visible = true;
               ButtonLogOut.Visible = true;
            }
            else if (Session["User"] != null && Session["Role"].ToString() == "Admin")
            {
                ButtonHome.Visible = true;
                ButtonAddJewel.Visible = true;
                ButtonReports.Visible = true;
                ButtonHandleOrders.Visible = true;
                ButtonProfile.Visible = true;
                ButtonLogOut.Visible = true;
            }
            if(Session["User"] != null)
            {
                MsUser sessionuser = (MsUser)Session["User"];
                Labelhello.Text = "Hello, " + sessionuser.UserName;
            }
            else
            {
                Labelhello.Text = "";
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
        protected void setButtonVisibility()
        {
            ButtonHome.Visible = false;
            ButtonRegister.Visible = false;
            ButtonLogin.Visible = false;
            ButtonCart.Visible = false;
            ButtonMyOrders.Visible = false;
            ButtonProfile.Visible = false;
            ButtonAddJewel.Visible = false;
            ButtonLogOut.Visible = false;
            ButtonAddJewel.Visible = false;
            ButtonReports.Visible = false;
            ButtonHandleOrders.Visible = false;
        }
        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session.Remove("User");
            Session.Remove("Role");
            HttpCookie cookie = Request.Cookies["Cookie"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-2);
                Response.Cookies.Add(cookie);
            }
            Response.Redirect("~/View/HomePage.aspx");
        }

        protected void ButtonAddJewel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~View/AddJewel.aspx");
        }

        protected void ButtonReports_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonHandleOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HandleOrders.aspx");
        }
    }
}