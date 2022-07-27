using EcommerceProjectReinTrng.DAL;
using EcommerceProjectReinTrng.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace EcommerceProjectReinTrng.Controllers
{
    public class UsersController : Controller
    {
        UsersDAL db = new UsersDAL();
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Users users)
        {
            try
            {
                int res = db.UserSignUp(users);
                if (res == 1)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(Users users)
        {
            Users user = db.UserLogin(users);
            if (user.Password == users.Password)
            {
                HttpContext.Session.SetString("username", user.FirstName + " " + user.LastName);
                HttpContext.Session.SetString("userid", user.Id.ToString());
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn");
        }
    }
}
