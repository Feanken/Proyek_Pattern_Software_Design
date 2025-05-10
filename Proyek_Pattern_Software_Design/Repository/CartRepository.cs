using Proyek_Pattern_Software_Design.Connection;
using Proyek_Pattern_Software_Design.Factory;
using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Repository
{
	public class CartRepository
	{
        CartFactory cartFactory = new CartFactory();
        Database1Entities db = DatabaseConnection.getInstance().getDB();
        public CartRepository()
        {
        }
        public Cart AddToCart(int userID, int jewelID)
        {
            Cart existingCart = db.Carts.Where(c => c.UserID == userID && c.JewelID == jewelID).FirstOrDefault();

            if (existingCart != null)
            {
                existingCart.Quantity += 1;
                db.SaveChanges();
                return existingCart;
            }
            else
            {
                Cart cart = cartFactory.createCart(userID, jewelID, 1);
                db.Carts.Add(cart);
                db.SaveChanges();
                return cart;
            }
        }
    }
}