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
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["MsUser"] == null || Request.Cookies["MsUser_Cookie"] == null)
            //{
            //    PanelHomePage.Visible = false;
            //}
            //else
            //{
            //    if (Session["MsUser"] == null)
            //    {
            //        int id = int.Parse(Request.Cookies["MsUser_Cookie"].Value);
            //        MsUser user = UserRepository.getuserid(id);
            //        Session["MsUser"] = user;
            //    }
            //    PanelHomePage.Visible = true;
            //    MsUser sessionuser = (MsUser)Session["MsUser"];
            //    Labelhello.Text = "Hello, " + sessionuser.UserName;
            //}
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}