using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyek_Pattern_Software_Design.Controller;
using Proyek_Pattern_Software_Design.Model;
using Proyek_Pattern_Software_Design.Repository;
using Proyek_Pattern_Software_Design.Utils;

namespace Proyek_Pattern_Software_Design.View
{
    public partial class LoginPage : System.Web.UI.Page
    {
        UserController userController = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
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
                    Response.Redirect("~/View/Homepage.aspx");
                }
            }
            if (!IsPostBack)
            {
                
            }
        }


        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string email = TextBoxEmail.Text;
            string pass = TextBoxPassword.Text;
            Boolean isRemember = CheckBoxCookie.Checked;

            Response<MsUser> response = userController.validateLogin(email, pass);
            if (response.statusCode == 200)
            {
                if (isRemember)
                {
                    HttpCookie cookie = new HttpCookie("Cookie");
                    cookie.Value = response.data.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                }

                Session["User"] = response.data;
                Session["Role"] = response.data.UserRole;
                Response.Redirect("~/view/homepage.aspx");

                LabelStatus.ForeColor = Color.Green;
                LabelStatus.Text = response.message + "\r\n" + response.data.UserName + ", Welcome Aboard!";
            }
            else
            {
                LabelStatus.ForeColor = Color.Red;
                LabelStatus.Text = response.message;
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/RegisterPage.aspx");
        }
    }
}