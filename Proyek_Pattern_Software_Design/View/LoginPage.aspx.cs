using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyek_Pattern_Software_Design.Model;
using Proyek_Pattern_Software_Design.Repository;

namespace Proyek_Pattern_Software_Design.View
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MsUser"] != null || Request.Cookies["MsUser_Cookie"] != null)
            {
                Response.Redirect("~/View/Homepage.aspx");
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            String email = TextBoxEmail.Text;
            String pass =  TextBoxPassword.Text;
            Boolean iremember = CheckBoxCookie.Checked;

            if (email == null || pass == null)
            {
                LabelStatus.Text = "Must be filled";
            }
            MsUser loginuser = UserRepository.LoginUser(email, pass);
            if(loginuser == null)
            {
                LabelStatus.Text = "Incorrect account";
            }
            else
            {
                if(iremember == null)
                {
                    HttpCookie cookie = new HttpCookie("MsUser_Cookie");
                    cookie.Value = loginuser.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                }
                Session["MsUser"] = loginuser;
                Response.Redirect("~/View/HomePage.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/RegisterPage.aspx");
        }
    }
}