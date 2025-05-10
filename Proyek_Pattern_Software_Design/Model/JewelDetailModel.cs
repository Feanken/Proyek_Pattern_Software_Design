using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Model
{
	public class JewelDetailModel
	{
        public string JewelName { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string Country { get; set; }
        public string Class { get; set; }
        public int Price { get; set; }
        public int ReleaseYear { get; set; }
    }
}