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
        public List<CartDetailModel> GetCart(int userID)
        {
            List<CartDetailModel> cartDetails = (from c in db.Carts
                                                 join j in db.MsJewels on c.JewelID equals j.JewelID
                                                 join m in db.MsBrands on j.BrandID equals m.BrandID
                                                 where c.UserID == userID
                                                 select new CartDetailModel
                                                 {
                                                     JewelID = j.JewelID.ToString(),
                                                     JewelName = j.JewelName,
                                                     JewelPrice = (int)j.JewelPrice,
                                                     Brand = m.BrandName,
                                                     Quantity = (int)c.Quantity,
                                                     Subtotal = (int)c.Quantity * (int)j.JewelPrice
                                                 }).ToList();
            return cartDetails;
        }
        public Cart removeCart(int id)
        {
            Cart cart = findByJewelID(id);
            if (cart != null)
            {
                db.Carts.Remove(cart);
                db.SaveChanges();
            }
            return cart;
        }
        public Cart findByJewelID(int id)
        {
            return db.Carts.Where(c => c.JewelID == id).FirstOrDefault();
        }

        public void updateQuantity(int userID, int jewelID, int quantity)
        {
            Cart selectedCart = findByJewelID(jewelID);
            if (selectedCart != null)
            {
                selectedCart.Quantity = quantity;
                db.SaveChanges();
            }
        }

        public void clearCart(int userID)
        {
            var cartItems = db.Carts.Where(c => c.UserID == userID);
            db.Carts.RemoveRange(cartItems);
            db.SaveChanges();
        }
    }
}