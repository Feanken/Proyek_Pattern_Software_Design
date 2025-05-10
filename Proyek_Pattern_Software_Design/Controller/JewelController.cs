using Proyek_Pattern_Software_Design.Handler;
using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Controller
{
    public class JewelController
    {
        JewelHandler jewelHandler = new JewelHandler();
        public JewelController()
        {
        }
        public List<MsJewel> getAllJewel()
        {
            return jewelHandler.getAllJewel();
        }
        public MsJewel getJewelByID(int jewelID)
        {
            return jewelHandler.getJewelByID(jewelID);
        }
        public JewelDetailModel getJewelDetail(int jewelID)
        {
            return jewelHandler.getJewelDetail(jewelID);
        }
        public MsJewel removeJewel(int jewelID)
        {
            return jewelHandler.removeJewel(jewelID);
        }
        public bool updateJewel(int jewelID, string name,int categoryID, int brandID, int price, int year)
        {
            return jewelHandler.updateJewel(jewelID, name, categoryID, brandID, price, year);
        }
        public bool addJewel(string name, int categoryID, int brandID, int price, int year)
        {
            return jewelHandler.addJewel(name, categoryID, brandID, price, year);
        }
    }
}