using Proyek_Pattern_Software_Design.Connection;
using Proyek_Pattern_Software_Design.Controller;
using Proyek_Pattern_Software_Design.Factory;
using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Repository
{
    public class JewelRepository
    {
        Database1Entities db = DatabaseConnection.getInstance().getDB();
        CategoryController categoryController = new CategoryController();
        BrandController brandController = new BrandController();
        JewelFactory jewelFactory = new JewelFactory();
        public JewelRepository()
        {
        }
        public List<MsJewel> getAllJewel()
        {
            return db.MsJewels.ToList();
        }
        public MsJewel getJewelByID(int jewelID)
        {
            return db.MsJewels.Find(jewelID);
        }
        public JewelDetailModel getJewelDetail(int jewelID)
        {
            MsJewel jewel = db.MsJewels.Find(jewelID);
            MsCategory category = categoryController.getCategoryByID(Convert.ToInt32(jewel.CategoryID));
            MsBrand brand = brandController.getBrandByID(Convert.ToInt32(jewel.BrandID));
            return new JewelDetailModel
            {
                JewelName = jewel.JewelName,
                CategoryName = category.CategoryName,
                BrandName = brand.BrandName,
                Country = brand.BrandCountry,
                Class = brand.BrandClass,
                Price = Convert.ToInt32(jewel.JewelPrice),
                ReleaseYear = Convert.ToInt32(jewel.JewelReleaseYear),
            };
        }

        public MsJewel removeJewel(int jewelID)
        {
            MsJewel jewel = db.MsJewels.Find(jewelID);

            if (jewel != null)
            {
                var relatedTransactionDetails = db.TransactionDetails
                                                  .Where(td => td.JewelID == jewelID)
                                                  .ToList();
                foreach (var td in relatedTransactionDetails)
                {
                    db.TransactionDetails.Remove(td);
                }
                
                var relatedCarts = db.Carts.Where(c => c.JewelID == jewelID).ToList();
                foreach (var cart in relatedCarts)
                {
                    db.Carts.Remove(cart);
                }

                db.MsJewels.Remove(jewel);
                db.SaveChanges();
            }

            return jewel;
        }

        public bool updateJewel(int jewelID, string name, int categoryID, int brandID, int price, int year)
        {
            MsJewel jewel = db.MsJewels.Find(jewelID);
            if (jewel != null)
            {
                jewel.JewelName = name;
                jewel.CategoryID = categoryID;
                jewel.BrandID = brandID;
                jewel.JewelPrice = price;
                jewel.JewelReleaseYear = year;
                db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
        public bool addJewel(string name, int categoryID, int brandID, int price, int year)
        {
            MsJewel jewel = jewelFactory.createJewel(name, categoryID, brandID, price, year);
            db.MsJewels.Add(jewel);
            db.SaveChanges();
            return true;
        }
    }
}