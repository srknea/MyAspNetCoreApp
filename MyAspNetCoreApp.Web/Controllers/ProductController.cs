using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository();

            if (!_productRepository.GetAll().Any())
            {
                _productRepository.Add(new() { Id = 1, Name = "Kalem", Price = 10, Stock = 100 });
                _productRepository.Add(new() { Id = 2, Name = "Defter", Price = 20, Stock = 200 });
                _productRepository.Add(new() { Id = 3, Name = "Silgi", Price = 30, Stock = 300 });
                //_productRepository.Add(new Product { Id = 4, Name = "Kalemtraş", Price = 40, Stock = 400 });
            }
    }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }
    }
}
