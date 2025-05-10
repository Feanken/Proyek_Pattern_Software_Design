using Proyek_Pattern_Software_Design.Model;
using Proyek_Pattern_Software_Design.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Handler
{
	public class BrandHandler
	{
        BrandRepository brandRepository = new BrandRepository();
        public BrandHandler()
        {
        }
        public MsBrand getBrandByID(int brandID)
        {
            return brandRepository.getBrandByID(brandID);
        }
    }
}