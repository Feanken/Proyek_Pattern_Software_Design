using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyek_Pattern_Software_Design.Factory;
using Proyek_Pattern_Software_Design.Repository;
using Proyek_Pattern_Software_Design.Model;



namespace Proyek_Pattern_Software_Design.View
{
    public partial class Homepage : System.Web.UI.Page
    {
        UserRepository userRepository = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["MsUser_Cookie"];

            if (Session["MsUser"] == null && cookie != null)
            {
                if (int.TryParse(cookie.Value, out int id))
                {
                    MsUser user = userRepository.getUserById(id);
                    if (user != null)
                    {
                        Session["MsUser"] = user;
                    }
                }
            }

            if (Session["MsUser"] != null)
            {
                PanelHomePage.Visible = true;
                MsUser sessionuser = (MsUser)Session["MsUser"];
                Labelhello.Text = "Hello, " + sessionuser.UserName;
            }
            else
            {
                PanelHomePage.Visible = false;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}