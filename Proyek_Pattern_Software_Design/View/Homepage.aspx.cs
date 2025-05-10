using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyek_Pattern_Software_Design.Factory;
using Proyek_Pattern_Software_Design.Repository;
using Proyek_Pattern_Software_Design.Model;
using Proyek_Pattern_Software_Design.Controller;
using System.Runtime.Remoting.Lifetime;



namespace Proyek_Pattern_Software_Design.View
{
    public partial class Homepage : System.Web.UI.Page
    {
        UserController controller = new UserController();
        JewelController jewelController = new JewelController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] == null)
                {
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

                PanelHomePage.Visible = Session["User"] != null;
                GridView1.DataSource = jewelController.getAllJewel();
                GridView1.DataBind();
            }

        }
        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetail") 
            {
                int jewelID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("~/View/JewelsDetail.aspx?jewelID=" + jewelID);
            }
        }
    }
}