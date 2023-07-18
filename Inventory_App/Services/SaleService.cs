using System.Collections.Generic;
using System.Linq;
using Inventory_App.IServices;
using Inventory_App.Models;
using Inventory_App.Resources;
using System.Data.Entity;
using Inventory_App.Migrations;
using System;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;

namespace Inventory_App.Services
{
    public class SaleService : ISaleService
    {
        private readonly AppsContext _db;
        public SaleService()
        {
            _db = new AppsContext();
        }

        public bool SaveSales(SalesResource sale)
        {
            var products = sale.SoldProductResources;
            products = products.Where(p => p.Quantity != 0).ToList();
            var NewSales = new Sale
            {
                Date = DateTime.Now,
                CustomerID = sale.CustomerID,

            };
            var saleproduct = new List<SoldProducts>();
            decimal total = 0;

            foreach (var item in products)
            {
                var product = new SoldProducts();
                product.Name = item.Name;
                product.ProductID = item.ProductID;
                product.Price = item.Price;
                product.Image = item.Image;
                product.Quantity = item.Quantity;

                var productreport = _db.productReports.FirstOrDefault(p => p.ProductID == item.ProductID);
                var instockquantity = productreport.InStockQuantity;

                if (item.Quantity > instockquantity)
                {
                    throw new Exception($"{product.Name} is out of stock");
                }

                total += (decimal)product.Price * product.Quantity;
                saleproduct.Add(product);
            }
            NewSales.Total=total;
            NewSales.SoldProducts = saleproduct;
            if (NewSales.SoldProducts.Count > 0)
            {
                _db.Sales.Add(NewSales);
                _db.SaveChanges();

            }

            return true;
        }


        public IEnumerable<SalesResource> GetAllSales()
        {
            var sales = _db.Sales.Include(p => p.Customer).ToList();
            var saleresourceList = new List<SalesResource>();
            foreach (var sale in sales)
            {
                var saleresource = new SalesResource
                {
                    Date = sale.Date,
                    CustomerID = sale.CustomerID,
                    Total = sale.Total,
                    Id = sale.Id,
                    Customer = sale.Customer,
                    CreatedBy=sale.CreatedBy
                    

                };
                saleresourceList.Add(saleresource);
            }
            return saleresourceList;
        }

        public void DeleteSales(int id)
        {
            var sale = _db.Sales.Include(p => p.SoldProducts).FirstOrDefault(p => p.Id == id);
            _db.SoldProducts.RemoveRange(sale.SoldProducts);
            _db.Sales.Remove(sale);
            _db.SaveChanges();

        }

        public SalesResource GetSalesByID(int id)
        {
            var sale = _db.Sales.Include(c => c.Customer)
                .Include(p => p.SoldProducts)
                .SingleOrDefault(p => p.Id == id);
            var saleresource = new SalesResource
            {
                Id = sale.Id,
                Date = sale.Date,
                Total = sale.Total,
                CustomerID = sale.CustomerID,
                Customer = sale.Customer,
                SoldProductResources = sale.SoldProducts.Select(p => new SoldProductResource
                {
                    ProductID = p.ProductID,
                    Price = p.Price,
                    Name = p.Name,
                    Quantity = p.Quantity,
                    Image= p.Image,

                }).ToList()
            };
            return saleresource;
        }


        public SalesResource GetProductDetails()
        {
            var list = new SalesResource();
            var products = new List<SoldProductResource>();
            var data = _db.Products.OrderBy(o => o.Name).ToList();
            foreach (var item in data)
            {
                var product = new SoldProductResource
                {
                    Name = item.Name,
                    ProductID = item.ID,
                    Price = item.Price,
                    Image = item.Image,
                };
                products.Add(product);
            }
            list.SoldProductResources = products;

            return list;

        }

       public IEnumerable<CustomerMemo> GetCustomer()
        {
            var data = _db.Customers.OrderBy(o => o.name).ToList()
               .Select(x => new CustomerMemo
               {
                   Id = x.id,
                   Name = x.name
               });
            return data;
        }


        public string GetSalesTotal()
        {
            decimal ?total = _db.Sales.Sum(x => x.Total);

           
            
            return total.ToString();
        }



    }




}

