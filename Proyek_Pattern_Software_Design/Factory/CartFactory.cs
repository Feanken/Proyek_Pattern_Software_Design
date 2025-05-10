using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Factory
{
	public class CartFactory
	{
		public CartFactory()
        {
        }
        public Cart createCart(int userID, int jewelID, int Quantity)
        {
            Cart cart = new Cart();
            cart.UserID = userID;
            cart.JewelID = jewelID;
            cart.Quantity = Quantity;
            return cart;
        }
    }
}