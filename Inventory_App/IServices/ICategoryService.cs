using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_App.Resources;

using Inventory_App.Models;


namespace Inventory_App.IServices
{
    public interface ICategoryService
    {
        Category SaveCategory(Category category);
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryByID(int id);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
        IEnumerable<CategoryResource> GetCategoryByName();
    }
}
