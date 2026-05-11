using System.Diagnostics;
using CoffeShop.Models;
using CoffeShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductRepository productRepository;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View(productRepository.GetAllProducts());
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
