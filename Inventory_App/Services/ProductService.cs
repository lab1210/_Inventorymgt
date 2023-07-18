using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Inventory_App.IServices;
using Inventory_App.Models;
using Inventory_App.Resources;


namespace Inventory_App.Services
{
    public class ProductService : IProductService
    {
        private readonly AppsContext _db;
        public ProductService()
        {
            _db = new AppsContext();
        }

        public Product SaveProduct(Product product)
        {
            this._db.Products.Add(product);
            this._db.SaveChanges();
            return product;
        }


        public IEnumerable<ProductResource> GetAllProducts()
        {
            var list = _db.Products
                .Include(x => x.Brand)
                .Include(x => x.Category)
                .Include(x => x.Unit)
                .ToList();

            var productResources = new List<ProductResource>();

            foreach (var product in list)
            {
                var purchasedQuantity = _db.PurchaseProducts
                    .Where(p => p.ProductID == product.ID)
                    .Sum(p => (int?)p.Quantity) ?? 0;

                 var soldQuantity = _db.SoldProducts
                     .Where(p => p.ProductID == product.ID)
                     .Sum(p => (int?)p.Quantity) ?? 0;
                var soldAmount = _db.SoldProducts
                    .Where(p=>p.ProductID==product.ID)
                    .Sum(c => (decimal?)c.Price *c.Quantity ) ?? 0;

                int stock = purchasedQuantity - soldQuantity;

                var productResource = new ProductResource
                {
                    ID = product.ID,
                    Name = product.Name,
                    StockKeepingUnit = product.StockKeepingUnit,
                    Price = product.Price,
                    Brand = product.Brand,
                    Category = product.Category,
                    Unit = product.Unit,
                    BrandID = product.BrandID,
                    CategoryID = product.CategoryID,
                    UnitID = product.UnitID,
                    InStockQuantity = stock,
                    SoldQuantity = soldQuantity,
                    SoldAmount = soldAmount,
                    ImagePath = product.Image
                };


            
              var existingreport=_db.productReports.FirstOrDefault(r=>r.ProductID==product.ID );
                if (existingreport==null)
                {
                    var reports = new ProductReport
                    {
                        ProductID = product.ID,
                        Name = product.Name,
                        InStockQuantity = stock,
                    };
                    _db.productReports.Add(reports);
                }
                else
                {
                    existingreport.InStockQuantity = stock;
                }
                _db.SaveChanges();


                productResources.Add(productResource);
            }

            return productResources;
        }


        public ProductResource GetProductByID(int id)
        {
            var product = _db.Products.
                Include(P => P.Brand)
                .Include(p => p.Unit)
                .Include(p => p.Category)
                .FirstOrDefault(p => p.ID == id);
            var products = new ProductResource
            {
                ID = product.ID,
                Price = product.Price,
                Name = product.Name,
                StockKeepingUnit = product.StockKeepingUnit,
                BrandID = product.BrandID,
                UnitID = product.UnitID,
                Brand = product.Brand,
                Unit = product.Unit,
                Category = product.Category,
                ImagePath = product.Image,
                CategoryID = product.CategoryID,


            };
            return products;
        }
        public void UpdateProduct(Product product)
        {
            var existingProduct = _db.Products.FirstOrDefault(p => p.ID == product.ID);

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.StockKeepingUnit = product.StockKeepingUnit;
                existingProduct.BrandID = product.BrandID;
                existingProduct.UnitID = product.UnitID;
                existingProduct.Brand = product.Brand;
                existingProduct.Category = product.Category;
                existingProduct.Image = product.Image;
                existingProduct.CategoryID = product.CategoryID;

                _db.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.ID == id);
            this._db.Products.Remove(product);
            this._db.SaveChanges();
        }
        public IEnumerable<ProductResource> GetProductByName()
        {
            var product1 = from c in _db.Products
                           select c;
            product1 = product1.Include(c => c.Brand)
                 .Include(c => c.Unit)
                 .Include(c => c.Category);

            var ProductList = new List<ProductResource>();
            foreach (var product in product1)
            {
                var productresource = new ProductResource
                {
                    Name = product.Name,
                    ID = product.ID,
                    BrandID = product.BrandID,
                    UnitID = product.UnitID,
                    CategoryID = product.CategoryID,
                    StockKeepingUnit = product.StockKeepingUnit,
                    Price = product.Price,
                    Brand = product.Brand,
                    Category = product.Category,
                    Unit = product.Unit,
                    ImagePath = product.Image,
                    CreatedBy = product.CreatedBy,

                };
                ProductList.Add(productresource);
            }
            return ProductList;
        }
        public IEnumerable<string> GetProductName()
        {
            var products = from d in _db.Products
                           select d.Name;

            return products;
        }
    }
}
