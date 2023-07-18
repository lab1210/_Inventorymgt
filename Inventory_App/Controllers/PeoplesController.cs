using System.Web.Mvc;
using Inventory_App.Services;
using Inventory_App.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Inventory_App.Controllers
{
    public class PeoplesController : Controller
    {
        private readonly PeopleService _peopleService;
        private readonly PlaceService _placeService;
        public PeoplesController()
        {
            _peopleService = new PeopleService();
            _placeService = new PlaceService();
        }
        // GET: Peoples
        public ActionResult CustomerList(string searchname, string searchphone)
        {

            var customers = _peopleService.GetCustomerByName();

            if (!string.IsNullOrEmpty(searchname))
            {

                customers = customers.Where(c => c.name.Contains(searchname));
            }

            if (!string.IsNullOrEmpty(searchphone))
            {
                customers = customers.Where(c => c.Phone == searchphone);
            }
            return View(customers);

        }

        public ActionResult EditCustomer(int id)
        {
            Customer customer = _peopleService.GetCustomerByID(id);
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer( Customer customer)
        {
            if (ModelState.IsValid)
            {
                _peopleService.UpdateCustomer(customer);
                return RedirectToAction("CustomerList");
            }
            return View(customer);

        }
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCustomer( Customer customer)
        {
            if (ModelState.IsValid)
            {
                var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;
                customer.CreatedBy = loggedInUserName;
                _peopleService.SaveCustomer(customer);
                return RedirectToAction("CustomerList");
            }
            return View(customer);
        }
        [HttpGet]
        public ActionResult DeleteConfirmedCustomer(int ID)
        {
            _peopleService.DeleteCustomer(ID);

            return RedirectToAction("CustomerList");
        }
        public ActionResult SupplierList(string searchname, string searchphone)
        {
            var suppliers = _peopleService.GetSupplierByName();

            if (!String.IsNullOrEmpty(searchname))
            {

                suppliers = suppliers.Where(c => c.name.Contains(searchname));

            }

            if (!String.IsNullOrEmpty(searchphone))
            {
                suppliers = suppliers.Where(c => c.phone == searchphone);
            }

            return View(suppliers);

        }

        public ActionResult EditSupplier(int id)
        {
            IEnumerable<Country> countrylist = _placeService.GetCountryList();
            IEnumerable<City> citylist = _placeService.GetCityList();
            ViewBag.CityList = new SelectList(citylist, "ID", "CityName");
            ViewBag.CountryList = new SelectList(countrylist, "ID", "CountryName");
            Supplier supplier = _peopleService.GetSupplierByID(id);
            return View(supplier);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSupplier(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _peopleService.UpdateSupplier(supplier);
                return RedirectToAction("SupplierList");
            }
            return View(supplier);

        }

        public ActionResult AddSupplier()
        {
            IEnumerable<Country> countrylist = _placeService.GetCountryList();
            IEnumerable<City> citylist = _placeService.GetCityList();
            ViewBag.CountryList = new SelectList(countrylist, "ID", "CountryName");
            ViewBag.CityList = new SelectList(citylist, "ID", "CityName");


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSupplier(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;
                supplier.CreatedBy=loggedInUserName;
                _peopleService.SaveSupplier(supplier);
                return RedirectToAction("SupplierList");
            }
            return View(supplier);
        }
        [HttpGet]
        public ActionResult DeleteConfirmedSupplier(int ID)
        {
            _peopleService.DeleteSupplier(ID);

            return RedirectToAction("SupplierList");
        }
    }
}