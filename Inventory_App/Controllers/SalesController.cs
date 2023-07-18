using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_App.Services;
using Inventory_App.Models;
using Inventory_App.Resources;

namespace Inventory_App.Controllers

{
    public class SalesController : Controller
    {
        private readonly SaleService _saleservice;
        private readonly ProductService productService;


        public SalesController()
        {
            _saleservice = new SaleService();
            productService = new ProductService();



        }

        public ActionResult AddSales()
        {
            productService.GetAllProducts();

            var customers = _saleservice.GetCustomer();
            ViewBag.Customer = customers;
            var details = _saleservice.GetProductDetails();

            return View(details);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSales(SalesResource sale)
        {
            try
            {
                var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;
                sale.CreatedBy = loggedInUserName;

                var result = _saleservice.SaveSales(sale);
                if (result)
                    return RedirectToAction("SalesList");
                else
                    return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                var customers = _saleservice.GetCustomer();
                ViewBag.Customer = customers;
                var details = _saleservice.GetProductDetails();

                return View(details);
            }
        }

        public ActionResult SalesDetails(int id)
        {
            SalesResource sale = _saleservice.GetSalesByID(id);
            return View(sale);

        }

        public ActionResult SalesList()
        {
            var saleresources = _saleservice.GetAllSales();



            return View(saleresources);
        }
        [HttpGet]
        public ActionResult DeleteSales(int id)
        {
            _saleservice.DeleteSales(id);
            return RedirectToAction("SalesList");

        }

    }




}
