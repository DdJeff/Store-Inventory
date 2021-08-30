﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Testing.Models;

namespace Testing.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IProductRepository repo;
       

        public HomeController(IProductRepository repo)
        { this.repo = repo;
            
        }

        //get all products
        public IActionResult Index()
        {
            var products = repo.GetAllProducts();
            return View(products);
        }

        //get product by id
        public IActionResult ViewProduct(int id)
        {
            var product = repo.GetProduct(id);
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
