using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_App.Models;
using Inventory_App.Resources;

using Inventory_App.Services;

namespace Inventory_App.Controllers
{
    public class DashBoardController : Controller
    {

        private readonly PeopleService peopleService;
        private readonly SaleService saleService;
        private readonly PurchaseService purchaseService;

        // GET: Purchases
        public DashBoardController()
        {

            peopleService = new PeopleService();
            saleService = new SaleService();
            purchaseService = new PurchaseService();
        }
        // GET: DashBoard
        public ActionResult Index()
        {
            var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;
            ViewBag.LoggedInUserName = loggedInUserName;
            //Count Number of Customers
            IEnumerable<Customer> customercount = peopleService.GetCustomerList();
            int CustomerCount = customercount.Count();
            ViewBag.Customercount = CustomerCount;

            //Count Number of Suppliers
            IEnumerable<Supplier> suppliercount = peopleService.GetSuppliername();
            int Suppliercount = suppliercount.Count();
            ViewBag.SupplierCount = Suppliercount;

            //Count Number of Purchases

            IEnumerable<PurchaseResources> purchasecount = purchaseService.GetAllPurchase();
            int PurchaseCount = purchasecount.Count();
            ViewBag.Purchasecount = PurchaseCount;

            //Count Number of Sales

            IEnumerable<SalesResource> salecount = saleService.GetAllSales();
            int SaleCount = salecount.Count();
            ViewBag.Salecount = SaleCount;

            //CGet Total sales

            string SalesAmount = saleService.GetSalesTotal();
            ViewBag.SalesAmount = SalesAmount;

            decimal TotalPurchases = purchaseService.GetTotalPurchases();
            ViewBag.PurchaseAmount = TotalPurchases;
            return View();
        }
    }
}