using Proyek_Pattern_Software_Design.Connection;
using Proyek_Pattern_Software_Design.Controller;
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
    }
}