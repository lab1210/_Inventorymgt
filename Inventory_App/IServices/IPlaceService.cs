using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_App.Models;


namespace Inventory_App.IServices
{
    public interface IPlaceService
    {
        Country SaveCountry(Country country);
        IEnumerable<Country> GetCountryList();
        Country GetCountryByID(int id);
        void UpdateCountry(Country country);
        void DeleteCountry(int id);
        City SaveCity(City city);
        IEnumerable<City> GetCityList();
        City GetCityByID(int id);
        void UpdateCity(City city);
        void DeleteCity(int id);
    }
}
