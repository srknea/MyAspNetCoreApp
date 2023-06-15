using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context;
        private readonly ProductRepository _productRepository;

        //Dependency Injection Pattern
        public ProductController(AppDbContext context) //DI Container
        {
            _productRepository = new ProductRepository();
            _context = context;
            /*
            if (!_context.Products.Any() == null)
            {
                _context.Products.Add(new Product() { Name = "Kalem", Price = 120, Stock = 10, Color = "Red" });
                _context.Products.Add(new Product() { Name = "Silgi", Price = 40, Stock = 20, Color = "Blue" });
                _context.Products.Add(new Product() { Name = "Defter", Price = 20, Stock = 30, Color = "Green" });

                _context.SaveChanges();
            }
            */
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);

            _context.SaveChanges();
            
            return RedirectToAction("Index");
            //return RedirectToAction(nameof(Index));
        }

        //[HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveProduct(string Name, decimal Price, int Stock, string Color)
        {
            Product newProduct = new Product() {Name = Name, Price = Price, Stock = Stock, Color = Color };

            _context.Products.Add(newProduct);

            _context.SaveChanges();

            return RedirectToAction("Index");   
        }

        public IActionResult Update(int id)
        {
            return View();
        }
    }
}
