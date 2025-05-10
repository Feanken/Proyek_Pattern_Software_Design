using Proyek_Pattern_Software_Design.Handler;
using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Controller
{
	public class CartController
    {
        CartHandler cartHandler = new CartHandler();
        public CartController()
        {
        }
        public Cart AddToCart(int userID, int jewelID)
        {
            return cartHandler.AddToCart(userID, jewelID);
        }
        public List<CartDetailModel> GetCart(int userID)
        {
            return cartHandler.GetCart(userID);
        }
        public Cart removeCart(int id)
        {
            return cartHandler.removeCart(id);
        }
        public void updateQuantity(int userID, int jewelid,int quantity)
        {
            cartHandler.updateQuantity(userID,jewelid, quantity);
        }
        public void clearCart(int userID)
        {
            cartHandler.clearCart(userID);
        }
    }
}