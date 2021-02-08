using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ElectronicShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Employee user, string returnUrl)
        {
            var db = new InternetProviderEntities();

            var dataItem = db.Employee.FirstOrDefault(x => x.Surname == user.Surname
                                                   && x.First_Name == user.First_Name
                                                   && x.Password == user.Password);
            if (dataItem != null)
            {
                FormsAuthentication.SetAuthCookie((dataItem.ID_Employee).ToString(), false);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Некоректні дані. Спробуйте ще раз.");
            return View();
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
    }
}