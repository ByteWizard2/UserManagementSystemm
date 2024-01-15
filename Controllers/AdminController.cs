using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserM.Models;
using UserManagementApp.DataBaseContext;

namespace USAD1.Controllers
{
    // Controllers/AdminController.cs
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Dashboard()
        {
            List<sign> objSignList = _db.Sign_Up.ToList();
            return View(objSignList);
        }

        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Access");

            return View();
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            
            sign? signFromDb  = _db.Sign_Up.Find(id);
            
            if (signFromDb == null)
            {

                return NotFound();
            }
            return View(signFromDb);
        }

         [HttpPost]
        public IActionResult Edit(sign gn)
        {
            if (ModelState.IsValid)
            {

                _db.Sign_Up.Update(gn);
                _db.SaveChanges();
                TempData["success"] = "Category Update successfully";
                return RedirectToAction("Dashboard", "Admin");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            sign? signFromDb = _db.Sign_Up.Find(id);
 
            if (signFromDb == null)
            {

                return NotFound();
            }
            return View(signFromDb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            sign? signFromDb = _db.Sign_Up.Find(id);
            if (signFromDb == null)
            {

                return NotFound();
            }

            _db.Sign_Up.Remove(signFromDb);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Dashboard", "Admin");
        
           

        }
    }
}
