using Proyek_Pattern_Software_Design.Connection;
using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Repository
{
	public class CategoryRepository
	{

        Database1Entities db = DatabaseConnection.getInstance().getDB();
        public CategoryRepository()
        {
        }
        public MsCategory getCategoryByID(int categoryID)
        {
            return db.MsCategories.Find(categoryID);
        }
    }
}