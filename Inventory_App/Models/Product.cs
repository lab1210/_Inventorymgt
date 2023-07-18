using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Inventory_App.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public string StockKeepingUnit { get; set; }
        [Required]

        public decimal Price { get; set; }


        public int BrandID { get; set; }
        public int CategoryID { get; set; }
        public int UnitID { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public Unit Unit { get; set; }
        public int InStockQuantity { get; set; }
        public int SoldQuantity { get; set; }
        public decimal SoldAmount { get; set; }

        public string Image { get; set; }

        public string CreatedBy { get; set; }



    }
    public class ProductReport
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int InStockQuantity { get; set; }

    }



}