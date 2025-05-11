using Proyek_Pattern_Software_Design.Controller;
using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyek_Pattern_Software_Design.View
{
	public partial class JewelsDetail : System.Web.UI.Page
	{
        private static int jewelID;
        CartController cartController = new CartController();
        protected void Page_Load(object sender, EventArgs e)
		{
            JewelController controller = new JewelController();
            HttpCookie cookie = Request.Cookies["Cookie"];
            if (cookie != null)
            {
                int userID = Convert.ToInt32(cookie.Value);
                UserController ucontroller = new UserController();
                MsUser user = ucontroller.getUserByID(userID);

                if (user != null)
                {
                    Session["User"] = user;
                    Session["Role"] = user.UserRole;
                }
            }
            if (Session["Role"] == null && Session["User"] == null)
            { 
                Response.Redirect("~/View/HomePage.aspx");
            }
            if (!IsPostBack)
            {
                string idParam = Request.QueryString["jewelID"];
                if (int.TryParse(idParam, out jewelID))
                {
                    LoadJewelDetail(jewelID);
                }
                else
                {
                    LabelError.Text = "Invalid Jewel ID.";
                }
            }
        }
        private void LoadJewelDetail(int id)
        {
            JewelController jewelController = new JewelController();
            JewelDetailModel jewel = jewelController.getJewelDetail(id);

            if (jewel != null)
            {
                LabelName.Text = jewel.JewelName;
                LabelCategory.Text = jewel.CategoryName;
                LabelBrand.Text = jewel.BrandName;
                LabelCountry.Text = jewel.Country;
                LabelClass.Text = jewel.Class;
                LabelPrice.Text = "$ " + jewel.Price.ToString("N0");
                LabelYear.Text = jewel.ReleaseYear.ToString();

                PanelDetail.Visible = true;

                var userRole = Session["Role"].ToString();
                if (userRole == "Customer")
                {
                    BtnAddToCart.Visible = true;
                }
                else if (userRole == "Admin")
                {
                    BtnEdit.Visible = true;
                    BtnDelete.Visible = true;
                }
            }
            else
            {
                LabelError.Text = "Jewel not found.";
            }
        }

        protected void BtnAddToCart_Click(object sender, EventArgs e)
        {
            MsUser user = (MsUser)Session["User"];
            if (user != null)
            {
                cartController.AddToCart(user.UserID, jewelID);
                Response.Redirect("~/View/CartPage.aspx");
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/EditJewel.aspx?jewelID=" + jewelID);
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            JewelController controller = new JewelController();
            controller.removeJewel(jewelID);
            Response.Redirect("~/View/HomePage.aspx");
        }
    }
}