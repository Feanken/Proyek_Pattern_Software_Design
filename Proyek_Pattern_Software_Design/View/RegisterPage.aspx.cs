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
    public partial class RegisterPage : System.Web.UI.Page
    {
        UserController UserController = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MsUser"] != null || Request.Cookies["MsUser_Cookie"] != null)
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
            if (!IsPostBack)
            {
                CalendarDateofBirth.TodaysDate = new DateTime(2010, 1, 1);
                CalendarDateofBirth.SelectedDate = CalendarDateofBirth.TodaysDate;
            }
        }

        protected void LinkButtonLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/LoginPage.aspx");
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            string email = TextBoxEmail.Text;
            string username = TextBoxUsername.Text;
            string password = TextBoxPassword.Text;
            string confirmpassword = TextBoxConfirmPassword.Text;
            string gendervalue = RadioButtonGender.SelectedValue;
            DateTime selectedDate = CalendarDateofBirth.SelectedDate;

            Response<MsUser> response = UserController.RegisterUser(email, username, password, confirmpassword, gendervalue, selectedDate);
            if (response.statusCode == 200)
            {
                LabelStatus.ForeColor = Color.Green;
                LabelStatus.Text = response.message;
            }
            else
            {
                LabelStatus.ForeColor = Color.Red;
                LabelStatus.Text = response.message;
            }
        }

        protected void CalendarDateofBirth_SelectionChanged1(object sender, EventArgs e)
        {

        }
    }
}