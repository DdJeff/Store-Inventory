using Testing.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Testing.Controllers
{
    public class ProductController1 : Controller
    {
        private readonly IProductRepository repo;


        public ProductController1(IProductRepository repo)
        {
            this.repo = repo;

        }

        public IActionResult Index()
        {
            var products = repo.GetAllProducts();
            return View(products);
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
