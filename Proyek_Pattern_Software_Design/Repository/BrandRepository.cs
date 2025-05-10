using Proyek_Pattern_Software_Design.Connection;
using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Repository
{
	public class BrandRepository
	{
        Database1Entities db = DatabaseConnection.getInstance().getDB();
        public BrandRepository()
        {
        }
        public MsBrand getBrandByID(int brandID)
        {
            return db.MsBrands.Find(brandID);
        }
    }
}