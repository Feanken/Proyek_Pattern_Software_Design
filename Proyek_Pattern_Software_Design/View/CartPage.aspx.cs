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
    public partial class CartPage : System.Web.UI.Page
    {
        CartController cartController = new CartController();
        TransactionController transactionController = new TransactionController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                if (role == null || role.ToString() != "Customer")
                {
                    Response.Redirect("~/View/HomePage.aspx");
                }
                LoadCartData();
            }
        }

        private void LoadCartData()
        {
            MsUser userlogin = (MsUser)Session["User"];
            int id = Convert.ToInt32(userlogin.UserID);
            GridView1.DataSource = cartController.GetCart(id);
            GridView1.DataBind();
            decimal total = 0;
            foreach (CartDetailModel item in cartController.GetCart(id))
            {
                total += item.Subtotal;
            }
            lblTotal.Text = $"Total: ${total:N2}";
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            cartController.removeCart(id);
            LoadCartData();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadCartData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadCartData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int jewelId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            GridViewRow row = GridView1.Rows[e.RowIndex];
            TextBox txtQty = (TextBox)row.FindControl("txtQuantity");
            MsUser userlogin = (MsUser)Session["User"];
            int userID = Convert.ToInt32(userlogin.UserID);
            int newQty;

            if (int.TryParse(txtQty.Text, out newQty) && newQty > 0)
            {
                cartController.updateQuantity(userID, jewelId, newQty);
                GridView1.EditIndex = -1;
                LoadCartData();
            }
        }

        protected void btnClearCart_Click(object sender, EventArgs e)
        {
            MsUser userlogin = (MsUser)Session["User"];
            int userID = Convert.ToInt32(userlogin.UserID);
            cartController.clearCart(userID);
            LoadCartData();
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlPayment.SelectedValue))
            {
                return;
            }

            MsUser userlogin = (MsUser)Session["User"];
            int userID = Convert.ToInt32(userlogin.UserID);
            string paymentMethod = ddlPayment.SelectedValue;

            transactionController.createTransaction(userID, paymentMethod);

            cartController.clearCart(userID);

            LoadCartData();
        
        }
    }
}