using Proyek_Pattern_Software_Design.Model;
using Proyek_Pattern_Software_Design.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Handler
{
	public class CartHandler
	{
        CartRepository cartRepository = new CartRepository();
        public CartHandler()
        {
        }
        public Cart AddToCart(int userID, int jewelID)
        {
            return cartRepository.AddToCart(userID, jewelID);
        }
    }
}