using Microsoft.AspNetCore.Mvc;
using UserM.Models;
using UserManagementApp.DataBaseContext;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace USAD1.Controllers
{
    public class HRController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HRController(ApplicationDbContext db)
        {
            this._db = db;
        }
        public IActionResult RegisterSave()
        {
            return View();

        }

        [HttpPost]
        public IActionResult RegisterDetails(sign gn)
        {
            if(ModelState.IsValid)
                {

                _db.Sign_Up.Add(gn);
                _db.SaveChanges();
                TempData["success"] = "Register successfully";
                return RedirectToAction("Login", "HR");
            }
            return View("RegisterSave", gn);



        }
      
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel lg)
        {
            var myUser = _db.Sign_Up.Where(x => x.UserName == lg.UserName && x.Password == lg.Password).FirstOrDefault();
            if (myUser != null)
            {
                HttpContext.Session.SetString("UserSession", myUser.UserName);
                TempData["success"] = "Login successfully";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Login Failed...";
            }
            return View();

        }

    }
}


