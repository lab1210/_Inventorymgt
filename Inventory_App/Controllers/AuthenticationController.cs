using Inventory_App.Services;
using Inventory_App.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_App.Controllers
{
    public class AuthenticationController : Controller
    {

        private readonly LoginService loginService;
        private readonly RegisterService registerService;
        public AuthenticationController()
        {
            loginService = new LoginService();
            registerService = new RegisterService();
        }
        // GET: Signin
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(Login login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    loginService.CheckUser(login);
                    
                    return RedirectToAction("Index", "DashBoard");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }



            }
            return View(login);
        }
        public ActionResult Forgotpswd ()
        {
            return View();
        }
        public ActionResult signup ()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult signup(Register register)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    registerService.AddUser(register);
                    return RedirectToAction("login", "Authentication");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);

                }

            }
            return View(register);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            loginService.clearLoginName();
            return RedirectToAction("login", "Authentication");

        }
    }
}