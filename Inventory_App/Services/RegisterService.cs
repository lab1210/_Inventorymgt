using Inventory_App.IServices;
using Inventory_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_App.Services
{
    public class RegisterService:IRegisterService
    {
        private readonly AppsContext _db;
        public RegisterService()
        {
            _db = new AppsContext();
        }

        public Register AddUser(Register register)
        {

            if (_db.registers.Any(r => r.FullName == register.FullName) || _db.registers.Any(r => r.Email == register.Email) || _db.registers.Any(r => r.Phone == register.Phone))
            {
                throw new Exception("User already exists");
            }


            _db.registers.Add(register);
            _db.SaveChanges();

            return register;
        }
    }
}