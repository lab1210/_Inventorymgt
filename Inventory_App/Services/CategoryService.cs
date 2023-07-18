using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_App.Models;
using Inventory_App.IServices;
using System.Data.Entity;
using Inventory_App.Resources;

namespace Inventory_App.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly AppsContext _db;
        public CategoryService()
        {
            _db = new AppsContext();
        }
        public Category SaveCategory(Category category)
        {
            this._db.Categories.Add(category);
            this._db.SaveChanges();
            return category;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return this._db.Categories.ToList();
        }
        public Category GetCategoryByID(int id)
        {
            return this._db.Categories.Find(id);
        }
        public void UpdateCategory(Category category)
        {
            var existingCategory = _db.Categories.FirstOrDefault(p => p.Id == category.Id);

            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Id = category.Id;
                existingCategory.ImagePath = category.ImagePath;
                existingCategory.CreatedBy = category.CreatedBy;



                _db.SaveChanges();
            }
        }
        public void DeleteCategory(int id)
        {
            var category1 = GetCategoryByID(id);
            this._db.Categories.Remove(category1);
            this._db.SaveChanges();
        }
        public IEnumerable<CategoryResource> GetCategoryByName()
        {
            var category1 = from c in this._db.Categories
                            select c;
           var categorylist=new List<CategoryResource>();
            foreach(var category in category1)
            {
                var categoryres = new CategoryResource
                {
                    Name = category.Name,
                    Id = category.Id,
                    ImagePath= category.ImagePath,
                    CreatedBy = category.CreatedBy, 
                };
                categorylist.Add(categoryres);
            }
            return categorylist;
        }
    }
}