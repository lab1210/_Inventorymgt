using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_App.Services;
using Inventory_App.Models;
using System.Web.Mvc;

namespace Inventory_App.Controllers
{
    public class ReportsController : Controller
    {

        private readonly ProductService _productservice;
        private readonly SaleService _saleservice;




        public ReportsController()
        {

            _productservice = new ProductService();

        }
        // GET: Reports

        public ActionResult InventoryReport()
        {

            return View(_productservice.GetAllProducts());


        }
        
        public ActionResult SalesReport()
        {
            return View(_productservice.GetAllProducts());

        }

    }
}