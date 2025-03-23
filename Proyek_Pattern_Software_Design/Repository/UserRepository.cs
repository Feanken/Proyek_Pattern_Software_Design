using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyek_Pattern_Software_Design.Factory;
using Proyek_Pattern_Software_Design.Model;

namespace Proyek_Pattern_Software_Design.Repository
{
    public class UserRepository
    {
        public static MsUser createnewuser(string email, string username,  string password, string gender, DateTime date)
        {
            DatabaseEntities1 db = new DatabaseEntities1 ();
            MsUser user = UserFactory.createnewUser(email, username, password, gender, date);
            db.MsUsers.Add(user);
            db.SaveChanges();
            return user;
        }
        public static MsUser LoginUser(string email, string password)
        {
            DatabaseEntities1 db = new DatabaseEntities1 ();
            MsUser loginuser = (from x in db.MsUsers where x.UserEmail == email && x.UserPassword == password select x).FirstOrDefault();
            return loginuser;
        }
        public static MsUser getuserid(int id)
        {
            DatabaseEntities1 db = new DatabaseEntities1();
            MsUser user = (from x in db.MsUsers where x.UserID == id select x).FirstOrDefault();
            return user;
        }
    }
}