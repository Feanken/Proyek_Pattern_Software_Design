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
    }
}