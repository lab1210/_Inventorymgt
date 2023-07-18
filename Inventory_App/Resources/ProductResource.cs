using Inventory_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_App.Resources
{
    public class ProductResource
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string StockKeepingUnit { get; set; }

        public decimal Price { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }

        public Unit Unit { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }
        public int UnitID { get; set; }
        public int InStockQuantity { get; set; }
        public int PurchasedQuantity { get; set; }
        public int SoldQuantity { get; set; }
        public decimal PurchasedAmount { get; set; }
        public decimal SoldAmount { get; set; }
        public string ImagePath { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string CreatedBy { get; set; }

    }
    public class ProductReportResource
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int InStockQuantity { get; set; }

    }
}