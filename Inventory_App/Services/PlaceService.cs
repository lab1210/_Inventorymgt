using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Inventory_App.IServices;
using Inventory_App.Models;
namespace Inventory_App.Services
{
    public class PlaceService:IPlaceService
    {
        private readonly AppsContext _db;
        public PlaceService()
        {
            _db = new AppsContext();
        }
        public Country SaveCountry(Country country)
        {
            this._db.Countries.Add(country);
            this._db.SaveChanges();
            return country;

        }
        public IEnumerable<Country> GetCountryList()
        {
            return this._db.Countries.ToList();
        }
        public Country GetCountryByID(int id)
        {
            return this._db.Countries.Find(id);
        }
        public void UpdateCountry(Country country)
        {
            this._db.Entry(country).State = EntityState.Modified;
            this._db.SaveChanges();
        }

        public void DeleteCountry(int id)
        {
            var country1 = GetCountryByID(id);
            this._db.Countries.Remove(country1);
            this._db.SaveChanges();
        }
        public City SaveCity(City city)
        {
            var country = _db.Countries.FirstOrDefault(c => c.ID == city.CountryID);

            if (country != null)
            {
                city.Country = country;
                this._db.Cities.Add(city);
                this._db.SaveChanges();

            }

            return city;
        }

        public IEnumerable<City> GetCityList()
        {
            return this._db.Cities.Include(c => c.Country).ToList();
        }
        public City GetCityByID(int id)
        {
            return this._db.Cities.Find(id);
        }
        public void UpdateCity(City city)
        {
            this._db.Entry(city).State = EntityState.Modified;
            this._db.SaveChanges();
        }

        public void DeleteCity(int id)
        {
            var city1 = GetCityByID(id);
            this._db.Cities.Remove(city1);
            this._db.SaveChanges();
        }
    }
}