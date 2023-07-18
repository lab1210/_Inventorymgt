using System.Collections.Generic;
using System.Linq;
using Inventory_App.IServices;
using Inventory_App.Models;
using Inventory_App.Resources;
using System.Data.Entity;
namespace Inventory_App.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly AppsContext _db;
        public PurchaseService()
        {
            _db = new AppsContext();
        }
        public bool SavePurchase(PurchaseResources purchase)
        {
            var products = purchase.purchaseResourceProducts;
            products = products.Where(p => p.Selected && p.Quantity != 0).ToList();


            var NewPurchase = new Purchase
            {
                Date = purchase.Date,
                SupplierID = purchase.SupplierID,
                Total = purchase.Total,
            };

            var purchaseproduct = new List<PurchaseProduct>();

            foreach (var item in products)
            {
                var product = new PurchaseProduct();
                product.Name = item.Name;
                product.ProductID = item.ProductID;
                product.Quantity = item.Quantity;
                product.Selected = item.Selected;

                purchaseproduct.Add(product);


            }
            NewPurchase.PurchaseProducts = purchaseproduct;
            if (NewPurchase.PurchaseProducts.Count > 0)
            {
                this._db.Purchases.Add(NewPurchase);
                this._db.SaveChanges();
            }

            return true;
        }




        public IEnumerable<PurchaseResources> GetAllPurchase()
        {

            var purchases = _db.Purchases.Include(p => p.Supplier).ToList();
            var purchaseResourcesList = new List<PurchaseResources>();

            foreach (var purchase in purchases)
            {

                var purchaseResource = new PurchaseResources
                {
                    Date = purchase.Date,
                    Total = purchase.Total,
                    SupplierID = purchase.SupplierID,
                    Supplier = purchase.Supplier,
                    ID = purchase.Id,
                    CreatedBy= purchase.CreatedBy,

                };

                purchaseResourcesList.Add(purchaseResource);
            }

            return purchaseResourcesList;
        }



        public void DeletePurchase(int id)
        {
            var purchase = _db.Purchases.Include(i => i.PurchaseProducts).FirstOrDefault(p => p.Id == id);
            _db.PurchaseProducts.RemoveRange(purchase.PurchaseProducts);
            _db.Purchases.Remove(purchase);
            _db.SaveChanges();

        }

        public PurchaseResources GetPurchase(int id)
        {
            var purchase = _db.Purchases.Include(p => p.Supplier)
                .Include(p => p.PurchaseProducts)
                .SingleOrDefault(p => p.Id == id);
            var purchaseResource = new PurchaseResources
            {
                ID = purchase.Id,
                Date = purchase.Date,
                Total = purchase.Total,
                SupplierID = purchase.SupplierID,
                Supplier = purchase.Supplier,
                purchaseResourceProducts = purchase.PurchaseProducts.Select(p => new PurchaseResourceProduct
                {
                    ProductID = p.ProductID,
                    Name = p.Name,
                    Quantity = p.Quantity,
                    Selected = p.Selected,
                }).ToList()
            };
            return purchaseResource;
        }






        public PurchaseResources GetProductPurchaseDetails()
        {
            var list = new PurchaseResources();
            var products = new List<PurchaseResourceProduct>();
            var data = _db.Products.OrderBy(o => o.Name).ToList();
            foreach (var item in data)
            {
                var product = new PurchaseResourceProduct
                {
                    Name = item.Name,
                    ProductID = item.ID,
                };
                products.Add(product);
            }
            list.purchaseResourceProducts = products;

            return list;
        }
        public IEnumerable<SupplierMemo> GetSupplier()
        {
            var data = _db.Suppliers.OrderBy(o => o.name).ToList()
                .Select(x => new SupplierMemo
                {
                    Id = x.id,
                    Name = x.name
                });
            return data;
        }

        public decimal GetTotalPurchases()
        {
            decimal total = _db.Purchases.Sum(x => x.Total);
            return total;
        }
    }



}
