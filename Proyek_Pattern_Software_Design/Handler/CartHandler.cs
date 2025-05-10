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
        public List<CartDetailModel> GetCart(int userID)
        {
            return cartRepository.GetCart(userID);
        }
        public Cart removeCart(int id)
        {
            return cartRepository.removeCart(id);
        }
        public void updateQuantity(int userID, int jewelID, int quantity)
        {
            cartRepository.updateQuantity(userID, jewelID, quantity);
        }
        public void clearCart(int userID)
        {
            cartRepository.clearCart(userID);
        }
    }
}