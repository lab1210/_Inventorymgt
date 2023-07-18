using Inventory_App.IServices;
using Inventory_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Xml.Linq;

namespace Inventory_App.Services
{
    public class LoginService : ILoginService
    {
        private readonly AppsContext _db;
        public LoginService()
        {
            _db = new AppsContext();
        }
        public Login CheckUser(Login login)
        {
            var registerduser = _db.registers.FirstOrDefault(r => r.Email == login.Email && r.Password == login.Password);
            if (registerduser == null)
            {
                throw new Exception("Invalid Email or Password");
            }
            LoginMemo loginMemo = new LoginMemo
            {
                Name = registerduser.FullName,
                Email=registerduser.Email,
                Phone=registerduser.Phone,

            };
            StoreLoginName(loginMemo.Name);
           
            login.LoggedInDate = DateTime.Now;
            _db.logins.Add(login);
            _db.SaveChanges();
            return login;
        }

        public void StoreLoginName(string name)
        {
            HttpContext.Current.Session["LoggedInUserName"] = name;
        }
      


        public void clearLoginName()
        {
            StoreLoginName(null);
           
        }


    }
}