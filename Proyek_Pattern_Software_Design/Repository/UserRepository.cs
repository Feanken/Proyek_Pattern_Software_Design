using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyek_Pattern_Software_Design.Connection;
using Proyek_Pattern_Software_Design.Factory;
using Proyek_Pattern_Software_Design.Model;

namespace Proyek_Pattern_Software_Design.Repository
{
    public class UserRepository
    {
        Database1Entities db = DatabaseConnection.getInstance().getDB();

        public MsUser getUserByUsername(string username)
        {
            return db.MsUsers.Where(u => u.UserName.Equals(username)).FirstOrDefault();
        }
        public void addUser(MsUser user)
        {
            db.MsUsers.Add(user);
            db.SaveChanges();
        }
        public MsUser getUser(string email, string password)
        {
            return db.MsUsers.Where(
                u => u.UserEmail.Equals(email) && u.UserPassword.Equals(password)
                ).FirstOrDefault();
        }
        public MsUser getUserById(int userID)
        {
            return db.MsUsers.Where(
                u => u.UserID.Equals(userID)).FirstOrDefault();
        }
    }
}