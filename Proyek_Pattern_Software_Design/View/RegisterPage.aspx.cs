using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyek_Pattern_Software_Design.Repository;

namespace Proyek_Pattern_Software_Design.View
{
    public partial class RegisterPage : System.Web.UI.Page
    {
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
            String email = TextBoxEmail.Text;
            String username = TextBoxUsername.Text;
            String password = TextBoxPassword.Text;
            String confirmpassword = TextBoxConfirmPassword.Text;
            String gendervalue = RadioButtonGender.SelectedValue;
            DateTime selectedDate = CalendarDateofBirth.SelectedDate;

            if (email == "" || username == "" || password == "" || confirmpassword == "" || gendervalue == "")
            {
                LabelStatus.Text = "Must be filled";
                return;
            }
            else if (!email.Contains("@") && !email.Contains("."))
            {
                LabelStatus.Text = "Must be Valid email Format";
                return;
            }
            else if (username.Length < 3 && username.Length > 25)
            {
                LabelStatus.Text = "Must be between 3 to 25 Characters";
                return;
            }
            else if (!password.All(char.IsLetter))
            {
                if (password.Length < 8 && password.Length > 20)
                {
                    LabelStatus.Text = "Must be 8 to 20 Characters";
                    return;
                }
                LabelStatus.Text = "Must be alphanumeric";
                return;
            }
            else if (password != confirmpassword)
            {
                LabelStatus.Text = "Must be same as password";
                return;
            }
            else if(gendervalue != "Male" && gendervalue != "Female")
            {
                LabelStatus.Text = "Must choice [one Male or Female]";
                return;
            }
            else if(selectedDate == DateTime.MinValue)
            {
                LabelStatus.Text = "Must be choice date";
                return;
            }
            else if(selectedDate >= new DateTime(2010,1,1))
            {
                LabelStatus.Text = "Must be earlier than 01-01-2010";
                return;
            }
            UserRepository.createnewuser(email,username,password,gendervalue,selectedDate);
            LabelStatus.Text = "Berhasil";
        }



        protected void CalendarDateofBirth_SelectionChanged1(object sender, EventArgs e)
        {

        }
    }
}