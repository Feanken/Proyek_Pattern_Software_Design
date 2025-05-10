using Proyek_Pattern_Software_Design.Factory;
using Proyek_Pattern_Software_Design.Model;
using Proyek_Pattern_Software_Design.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Handler
{
    public class JewelHandler
    {
        JewelRepository jewelRepository = new JewelRepository();
        public JewelHandler()
        {
        }
        public List<MsJewel> getAllJewel()
        {
            return jewelRepository.getAllJewel();
        }
        public MsJewel getJewelByID(int jewelID)
        {
            return jewelRepository.getJewelByID(jewelID);
        }
        public JewelDetailModel getJewelDetail(int jewelID)
        {
            return jewelRepository.getJewelDetail(jewelID);
        }
        public MsJewel removeJewel(int jewelID)
        {
            return jewelRepository.removeJewel(jewelID);
        }
        public bool updateJewel(int jewelID, string name, int categoryID, int brandID, int price, int year)
        {
            return jewelRepository.updateJewel(jewelID, name,categoryID, brandID, price, year);
        }
        public bool addJewel(string name, int categoryID, int brandID, int price, int year)
        {
            return jewelRepository.addJewel(name, categoryID, brandID, price, year);
        }
    }
}