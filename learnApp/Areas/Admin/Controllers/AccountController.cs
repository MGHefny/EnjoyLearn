using learnApp.Areas.Admin.Models;
using learnApp.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace learnApp.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account/Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel logininfo)
        {
            //login controller
            var adminService = new AdminService();
            var isLoggedIn = adminService.login(logininfo.Email, logininfo.Password);
            if (isLoggedIn)
            {
                return RedirectToAction("Index", "Default");

            }
            else
            {
                //error message 
                logininfo.Message = "Email or Password is incorrect!";
                return View(logininfo);
            }
        }
    }
}