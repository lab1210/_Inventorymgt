using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_App.Services;
using Inventory_App.Models;
using System.Net;

namespace Inventory_App.Controllers
{
    public class PlacesController : Controller
    {
        private readonly PlaceService _placeService;
        public PlacesController()
        {
            _placeService = new PlaceService();
        }
        // GET: Places
        public ActionResult CountryList()
        {
            return View(_placeService.GetCountryList());
        }

        public ActionResult EditCountry(int id)
        {
            Country country = _placeService.GetCountryByID(id);

            return View(country);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCountry([Bind(Include = "ID,CountryName,Status")] Country country)
        {
            if (ModelState.IsValid)
            {
                _placeService.UpdateCountry(country);
                return RedirectToAction("CountryList");
            }
            return View(country);

        }


        public ActionResult NewCountry()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewCountry([Bind(Include = "ID,CountryName")] Country country)
        {
            if (ModelState.IsValid)
            {
                var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;
                country.CreatedBy = loggedInUserName;
                _placeService.SaveCountry(country);
                return RedirectToAction("CountryList");
            }
            return View(country);

        }

        [HttpGet]
        public ActionResult DeleteConfirmedCountry(int ID)
        {
            _placeService.DeleteCountry(ID);

            return RedirectToAction("CountryList");
        }
        [HttpGet]
        public ActionResult DeleteConfirmedState(int ID)
        {
            _placeService.DeleteCity(ID);

            return RedirectToAction("StateList");
        }
        public ActionResult NewState()
        {
            IEnumerable<Country> countryList = _placeService.GetCountryList();
            ViewBag.CountryList = new SelectList(countryList, "ID", "CountryName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewState([Bind(Include = "ID,CityName,CountryID,Country")] City city)
        {
            if (ModelState.IsValid)
            {
                var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;
                city.CreatedBy = loggedInUserName;

                _placeService.SaveCity(city);
                return RedirectToAction("StateList");
            }
            return View(city);

        }
        public ActionResult StateList()
        {


            return View(_placeService.GetCityList());

        }





        public ActionResult EditState(int id)
        {
            IEnumerable<Country> countryList = _placeService.GetCountryList();
            ViewBag.CountryList = new SelectList(countryList, "ID", "CountryName");
            City city = _placeService.GetCityByID(id);


            return View(city);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditState([Bind(Include = "ID,CityName,CountryID,Country,status")] City city)
        {
            if (ModelState.IsValid)
            {
                _placeService.UpdateCity(city);
                return RedirectToAction("StateList");
            }
            return View(city);

        }

    }
}