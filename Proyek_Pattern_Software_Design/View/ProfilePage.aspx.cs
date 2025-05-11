using Proyek_Pattern_Software_Design.Controller;
using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyek_Pattern_Software_Design.View
{
	public partial class ProfilePage : System.Web.UI.Page
	{
        UserController controller = new UserController();
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
                    MsUser user = controller.getUserByID(userID);
                    if (user != null)
                    {
                        Session["User"] = user;
                        Session["Role"] = user.UserRole;
                    }
                }
                
            }
		}

        protected void txtOldPassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtNewPassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            MsUser user = (MsUser)Session["User"];

            if (user.UserPassword != oldPassword)
            {
                lblMessage.Text = "Old password is incorrect.";
                return;
            }

            if (newPassword.Length < 8 || newPassword.Length > 25 || !IsAlphanumeric(newPassword))
            {
                lblMessage.Text = "New password must be 8–25 characters and alphanumeric.";
                return;
            }

            if (newPassword != confirmPassword)
            {
                lblMessage.Text = "Passwords do not match.";
                return;
            }
            controller.updatePassword(user.UserID, newPassword);
            Session["User"] = user;

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Password changed successfully.";
        }

        private bool IsAlphanumeric(string input)
        {
            return input.All(char.IsLetterOrDigit);
        }
    }
}