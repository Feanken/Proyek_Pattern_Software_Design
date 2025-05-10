using Proyek_Pattern_Software_Design.Controller;
using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyek_Pattern_Software_Design.View
{
	public partial class AddJewell : System.Web.UI.Page
	{
        CategoryController categoryController = new CategoryController();
        BrandController brandController = new BrandController();
        JewelController jewelController = new JewelController();
        protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["User"] == null && Request.Cookies["Cookie"] == null)
            {
                Response.Redirect("~/View/Homepage.aspx");
            }

            HttpCookie cookie = Request.Cookies["Cookie"];
            if (cookie != null)
            {
                int userID = Convert.ToInt32(cookie.Value);
                UserController controller = new UserController();
                MsUser user = controller.getUserByID(userID);

                if (user != null)
                {
                    Session["User"] = user;
                    Session["Role"] = user.UserRole;
                }
            }
            var role = Session["Role"];
            if (role == null || role.ToString() != "Admin")
            {
                Response.Redirect("~/View/HomePage.aspx");
            }

            if (!IsPostBack)
            {
                LoadDropdowns();
            }
        }

        private void LoadDropdowns()
        {
            List<MsCategory> categories = categoryController.getAllCategories();
            DDLCategory.DataSource = categories;
            DDLCategory.DataTextField = "CategoryName";
            DDLCategory.DataValueField = "CategoryID";
            DDLCategory.DataBind();

            List<MsBrand> brands = brandController.getAllBrands();
            DDLBrand.DataSource = brands;
            DDLBrand.DataTextField = "BrandName";
            DDLBrand.DataValueField = "BrandID";
            DDLBrand.DataBind();
        }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string name = TxtName.Text.Trim();
            string priceText = TxtPrice.Text.Trim();
            string yearText = TxtYear.Text.Trim();
            int currentYear = DateTime.Now.Year;

            if (name.Length < 3 || name.Length > 25)
            {
                LabelMessage.Text = "Jewel name must be between 3 to 25 characters.";
                return;
            }

            if (!int.TryParse(priceText, out int price) || price <= 25)
            {
                LabelMessage.Text = "Price must be a number greater than $25.";
                return;
            }

            if (!int.TryParse(yearText, out int year) || year >= currentYear)
            {
                LabelMessage.Text = "Release year must be a number less than the current year.";
                return;
            }

            int categoryID = int.Parse(DDLCategory.SelectedItem.Value);
            int brandID = int.Parse(DDLBrand.SelectedItem.Value);

            bool result = jewelController.addJewel(name, categoryID, brandID, price, year);

            if (result)
            {
                LabelMessage.ForeColor = System.Drawing.Color.Green;
                LabelMessage.Text = "Jewel successfully added.";
            }
            else
            {
                LabelMessage.Text = "Failed to add jewel.";
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HomePage.aspx");
        }

        protected void DDLCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLBrand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}