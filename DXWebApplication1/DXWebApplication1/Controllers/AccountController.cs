using DXWebApplication1.Infrastructure;
using DXWebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXWebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel credentials)
        {
            if(true)
            {
                AuthenticationManager.SetAuthCookie(credentials);
                return View("../Home/Maps");
            }
            else
            {
                return View("Login");
            }
        }
    }
}