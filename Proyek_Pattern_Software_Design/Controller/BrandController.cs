using Proyek_Pattern_Software_Design.Handler;
using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Controller
{
	public class BrandController
	{
        BrandHandler brandHandler = new BrandHandler();
        public BrandController()
        {
        }
        public MsBrand getBrandByID(int brandID)
        {
            return brandHandler.getBrandByID(brandID);
        }
        public List<MsBrand> getAllBrands()
        {
            return brandHandler.getAllBrands();
        }
    }
}