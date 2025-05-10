using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Factory
{
	public class JewelFactory
	{
		public JewelFactory()
        {
        }
        public MsJewel createJewel(string name, int categoryID, int brandID, int price, int year)
        {
            MsJewel jewel = new MsJewel();
            jewel.JewelName = name;
            jewel.JewelPrice = price;
            jewel.JewelReleaseYear = year;
            jewel.CategoryID = categoryID;
            jewel.BrandID = brandID;
            return jewel;
        }
    }
}