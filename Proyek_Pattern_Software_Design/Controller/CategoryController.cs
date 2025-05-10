using Proyek_Pattern_Software_Design.Handler;
using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Controller
{
	public class CategoryController
	{
        CategoryHandler CategoryHandler = new CategoryHandler();
        public CategoryController()
        {
        }
        public MsCategory getCategoryByID(int categoryID)
        {
            return CategoryHandler.getCategoryByID(categoryID);
        }
        public List<MsCategory> getAllCategories()
        {
            return CategoryHandler.getAllCategories();
        }
    }
}