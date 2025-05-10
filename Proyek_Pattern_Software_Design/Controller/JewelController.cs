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
    }
}