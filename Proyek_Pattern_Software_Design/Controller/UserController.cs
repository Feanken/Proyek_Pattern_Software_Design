using Proyek_Pattern_Software_Design.Handler;
using Proyek_Pattern_Software_Design.Model;
using Proyek_Pattern_Software_Design.Repository;
using Proyek_Pattern_Software_Design.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Controller
{
	public class UserController
	{
        UserHandler userHandler = new UserHandler();
        public UserController() { }
        public Response<MsUser> validateLogin(string email, string pass)
        {
            if (email == null || pass == null)
            {
                return new Response<MsUser>(400, "email or Password is empty", null);
            }
            MsUser loginuser = userHandler.getUser(email, pass);
            if (loginuser == null)
            {
                return new Response<MsUser>(400, "Username or password invalid", null);
            }
            return new Response<MsUser>(200, "User is valid", loginuser);
        }

        public Response<MsUser> RegisterUser(string email,string username,string password,string confirmpassword,string gendervalue,DateTime selectedDate)
        {
            if (email == "" || username == "" || password == "" || confirmpassword == "" || gendervalue == "")
            {
                return new Response<MsUser>(400, "Must be filled", null);
            }
            else if (!email.Contains("@") || !email.Contains(".") || email.Last() == '.')
            {
                return new Response<MsUser>(400, "Must be a valid email format", null);
            }
            else if (username.Length < 3 || username.Length > 25)
            {
                return new Response<MsUser>(400, "Username must be between 3 to 25 characters", null);
            }
            else if (!password.All(char.IsLetterOrDigit))
            {
                return new Response<MsUser>(400, "Password must be alphanumeric", null);
            }
            else if (password.Length < 8 || password.Length > 20)
            {
                return new Response<MsUser>(400, "Password must be 8 to 20 characters", null);
            }
            else if (password != confirmpassword)
            {
                return new Response<MsUser>(400, "Password and confirmation must match", null);
            }
            else if (gendervalue != "Male" && gendervalue != "Female")
            {
                return new Response<MsUser>(400, "Gender must be either Male or Female", null);
            }

            if (selectedDate == DateTime.MinValue)
            {
                return new Response<MsUser>(400, "Please select a valid date", null);
            }

            if (selectedDate >= new DateTime(2010, 1, 1))
            {
                return new Response<MsUser>(400, "Date must be earlier than 01-01-2010", null);
            }

            MsUser duplicateUsername = userHandler.getuserByUsername(username);
            MsUser duplicateEmail = userHandler.getUserByEmail(email);
            if (duplicateEmail == null && duplicateUsername == null)
            {
                userHandler.handleUserRegister(email, username, password, confirmpassword, gendervalue, selectedDate);
                return new Response<MsUser>(200, "User Successfully Register", null);
            }
            else if (duplicateEmail != null)
            {
                return new Response<MsUser>(400, "Email already exist", null);
            }
            else if (duplicateUsername != null)
            {
                return new Response<MsUser>(400, "Username already exist", null);

            }
            return new Response<MsUser>(400, "Username already exist", null);
        }
        public MsUser getUserByID(int userID)
        {
            return userHandler.getUserByID(userID);
        }
        public void updatePassword(int userID, string newPassword)
        {
            userHandler.updatePassword(userID, newPassword);
        }
    }
}
