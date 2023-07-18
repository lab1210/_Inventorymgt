using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_App.Models;

namespace Inventory_App.IServices
{
    public interface IUnitService
    {
        Unit SaveUnit(Unit unit);
        IEnumerable<Unit> GetAllUnits();
        Unit GetUnitByID(int id);
        void UpdateUnit(Unit unit);
        void Deleteunit(int id);
    }
}
