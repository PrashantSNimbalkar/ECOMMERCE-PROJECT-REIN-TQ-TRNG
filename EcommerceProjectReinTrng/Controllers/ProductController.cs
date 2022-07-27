using EcommerceProjectReinTrng.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Collections;
using EcommerceProjectReinTrng.Models;

namespace EcommerceProjectReinTrng.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL db = new ProductDAL();
        CartDAL cd = new CartDAL();
        public IActionResult Index()
        {
            var model = db.GetAllProducts();
            return View(model);
        }

        public IActionResult AddProductToCart(int id)
        {
            string userid = HttpContext.Session.GetString("userid");
            Cart cart = new Cart();
            cart.Id = id;
            cart.UserId = Convert.ToInt32(userid);
            int res = cd.AddToCart(cart);
            if (res == 1)
            {
                return RedirectToAction("ViewCart");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult ViewCart()
        {
            string userid = HttpContext.Session.GetString("userid");
            var model = cd.ViewProductsFromCart(userid);
            return View(model);
        }

        [HttpGet]
        public IActionResult RemoveFromCart(int cid)
        {
            int res = cd.RemoveFromCart(cid);
            if (res == 1)
            {
                return RedirectToAction("ViewCart");
            }
            else
            {
                return View();
            }
        }


    }
}
