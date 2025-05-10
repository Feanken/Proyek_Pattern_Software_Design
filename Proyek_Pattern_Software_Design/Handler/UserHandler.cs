using Proyek_Pattern_Software_Design.Factory;
using Proyek_Pattern_Software_Design.Model;
using Proyek_Pattern_Software_Design.Repository;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Handler
{
    public class UserHandler
    {
        UserRepository repository = new UserRepository();
        public UserHandler() { }
        public MsUser getuserByUsername(string username)
        {
            return repository.getUserByUsername(username);
        }
        public void handleUserRegister(string email, string username, string password, string confirmpassword, string gendervalue, DateTime selectedDate)
        {
            MsUser newUser = UserFactory.CreateUser(email, username, password, gendervalue, selectedDate);
            repository.addUser(newUser);
        }
        public MsUser getUser(string email, string password)
        {
            return repository.getUser(email, password);
        }
        public MsUser getUserByEmail(string email)
        {
            return repository.getUserByEmail(email);
        }
    }
}