using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_App.Models;
using Inventory_App.IServices;
using System.Data.Entity;

namespace Inventory_App.Services
{
    public class UnitService:IUnitService
    {
        private readonly AppsContext _db;
        public UnitService()
        {
            _db = new AppsContext();
        }
        public Unit SaveUnit(Unit unit)
        {
            var noneUnit = _db.Units.FirstOrDefault(u => u.Name == "None");

            if (noneUnit == null)
            {
                noneUnit = new Unit { Name = "None" };
                _db.Units.Add(noneUnit);
                _db.SaveChanges();
            }
            this._db.Units.Add(unit);
            this._db.SaveChanges();
            return unit;
        }

        public IEnumerable<Unit> GetAllUnits()
        {
           
            return this._db.Units.ToList();
        }
        public Unit GetUnitByID(int id)
        {
            return this._db.Units.Find(id);
        }
        public void UpdateUnit(Unit unit)
        {
            this._db.Entry(unit).State = EntityState.Modified;
            this._db.SaveChanges();
        }
        public void Deleteunit(int id)
        {
            var units = GetUnitByID(id);
            this._db.Units.Remove(units);
            this._db.SaveChanges();
        }
    }
}