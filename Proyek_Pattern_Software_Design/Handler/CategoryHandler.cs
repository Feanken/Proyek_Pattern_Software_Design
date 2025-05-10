using Proyek_Pattern_Software_Design.Model;
using Proyek_Pattern_Software_Design.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Handler
{
	public class CategoryHandler
	{
        CategoryRepository categoryRepository = new CategoryRepository();
        public CategoryHandler()
        {
        }
        public MsCategory getCategoryByID(int categoryID)
        {
            return categoryRepository.getCategoryByID(categoryID);
        }
    }
}