using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IProductRepository repo;

       

        
        public HomeController(IProductRepository repo)
        { this.repo = repo;

            
            
        }

        /// <summary>
        ///  This controller
        /// </summary>
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

        public IActionResult UpdateProduct(int id)
        {
            Product prod = repo.GetProduct(id);
            if (prod == null)
            {
                return View("ProductNotFound");
            }
            return View(prod);
        }

        public IActionResult UpdateProductToDatabase(Product product)
        {
            repo.UpdateProduct(product);
            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }

            public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult InsertProduct()
        {
            var prod = repo.AssignCategory();
            return View(prod);
        }

        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            repo.InsertProduct(productToInsert);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult DeleteProduct(Product product)
        {
            repo.DeleteProduct(product);
            return RedirectToAction("Index");
        }
    }
}
