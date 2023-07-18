using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Inventory_App.IServices;
using Inventory_App.Models;

namespace Inventory_App.Services
{
    public class BrandService : IBrandService
    {
        private readonly AppsContext _db;
        public BrandService()
        {
            _db = new AppsContext();
        }
        public Brand SaveBrand(Brand brand)
        {
           
            this._db.Brands.Add(brand);
            this._db.SaveChanges();
            return brand;
        }
        public IEnumerable<Brand> GetAllBrands()
        {
            return this._db.Brands.ToList();
        }
        public Brand GetBrandByID(int id)
        {
            return this._db.Brands.Find(id);
        }
        public void UpdateBrand(Brand brand)
        {
            this._db.Entry(brand).State = EntityState.Modified;
            this._db.SaveChanges();
        }
        public void DeleteBrand(int id)
        {
            var brand = GetBrandByID(id);
            this._db.Brands.Remove(brand);
            this._db.SaveChanges();
        }
        public IEnumerable<Brand> GetBrandByName()
        {
            var brand1 = from c in _db.Brands
                         select c;
            return brand1;
        }
    }
}