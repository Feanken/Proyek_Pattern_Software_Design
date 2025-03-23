using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyek_Pattern_Software_Design.Model;

namespace Proyek_Pattern_Software_Design.Factory
{
    public class UserFactory
    {
        public static MsUser createnewUser(string email, string username, string password, string gender, DateTime date)
        {
            MsUser user = new MsUser();
            user.UserName = username;
            user.UserEmail = email;
            user.UserGender = gender;
            user.UserPassword = password;
            user.UserDOB = date;
            user.UserRole = "Customer";
            return user;
        }
    }
}