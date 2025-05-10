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
	public partial class EditJewel : System.Web.UI.Page
	{
        private int jewelID;
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
                string idParam = Request.QueryString["jewelID"];
                if (int.TryParse(idParam, out jewelID))
                {
                    LoadJewel(jewelID);
                    LoadCategoriesAndBrands();
                }
                else
                {
                    LabelMessage.Text = "Invalid Jewel ID.";
                }
            }
        }
        private void LoadCategoriesAndBrands()
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
        private void LoadJewel(int id)
        {
            MsJewel jewel = jewelController.getJewelByID(id);
            if (jewel != null)
            {
                TxtName.Text = jewel.JewelName;
                TxtPrice.Text = jewel.JewelPrice.ToString();
                TxtYear.Text = jewel.JewelReleaseYear.ToString();
                DDLCategory.SelectedValue = jewel.CategoryID.ToString();
                DDLBrand.SelectedValue = jewel.BrandID.ToString();
            }
            else
            {
                LabelMessage.Text = "Jewel not found.";
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string idParam = Request.QueryString["jewelID"];
            if (!int.TryParse(idParam, out jewelID))
            {
                LabelMessage.Text = "Invalid Jewel ID.";
                return;
            }
            string name = TxtName.Text;
            int categoryID = int.Parse(DDLCategory.SelectedValue);
            int brandID = int.Parse(DDLBrand.SelectedValue);
            int price = int.Parse(TxtPrice.Text);
            int year = int.Parse(TxtYear.Text);

            if (name.Length < 3 || name.Length > 25)
            {
                LabelMessage.Text = "Jewel name must be between 3 and 25 characters.";
                return;
            }

            if (categoryID == 0 || brandID == 0)
            {
                LabelMessage.Text = "Please select both category and brand.";
                return;
            }

            if (!int.TryParse(TxtPrice.Text, out price) || price <= 25)
            {
                LabelMessage.Text = "Price must be a number greater than $25.";
                return;
            }

            if (!int.TryParse(TxtYear.Text, out year) || year >= DateTime.Now.Year)
            {
                LabelMessage.Text = "Release year must be a number less than the current year.";
                return;
            }

            bool updated = jewelController.updateJewel(jewelID, name, categoryID, brandID, price, year);

            if (updated)
            {
                LabelMessage.Text = "Jewel updated successfully.";
                LabelMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                LabelMessage.Text = "Update failed.";
            }

        }
    }
}