using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Model
{
	public class CartDetailModel
	{
        public string JewelID { get; set; }
        public string JewelName { get; set; }
        public int JewelPrice { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public int Subtotal { get; set; }
    }
}