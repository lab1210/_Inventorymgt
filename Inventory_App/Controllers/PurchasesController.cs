using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_App.Services;
using Inventory_App.Models;
using Inventory_App.Resources;

namespace Inventory_management.Controllers
{
    public class PurchasesController : Controller
    {
        private readonly PurchaseService _purchaseService;
        // GET: Purchase
        public PurchasesController()
        {
            _purchaseService = new PurchaseService();

        }
        public ActionResult AddPurchase()
        {
           
            var suppliers = _purchaseService.GetSupplier();
            ViewBag.Supplier = suppliers;
            var details = _purchaseService.GetProductPurchaseDetails();


            return View(details);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPurchase(PurchaseResources purchase)
        {
            var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;
            purchase.CreatedBy = loggedInUserName;

            var result = _purchaseService.SavePurchase(purchase);
            if (result)
                return RedirectToAction("PurchaseList");
            else
                return View();

        }

        



        public ActionResult PurchaseList()
        {

            var purchaseResources = _purchaseService.GetAllPurchase();



            return View(purchaseResources);

        }
        public ActionResult PurchaseDetails(int id)
        {
            
            PurchaseResources purchase = _purchaseService.GetPurchase(id);
            return View(purchase);
        }

        [HttpGet]
        public ActionResult deletepurchase(int id)
        {
            _purchaseService.DeletePurchase(id);
            return RedirectToAction("PurchaseList");

        }
    }
}