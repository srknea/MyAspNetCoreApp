using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;

        //Dependency Injection Pattern
        public ProductsController(AppDbContext context, IMapper mapper) //DI Container
        {
            _productRepository = new ProductRepository();
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();

            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        //[Route("[action]/{page}/{pageSize}")]
        [Route("[controller]/[action]/{page}/{pageSize}")]
        public IActionResult Pages(int page, int pageSize)
        {
            var products = _context.Products.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.page = page;
            ViewBag.pageSize = pageSize;

            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        //[Route("[controller]/[action]/{productid}")]
        //[Route("[action]/{productid}")]
        //[Route("detay/{productid}")]
        [Route("urunler/detay/{productid}")]
        public IActionResult GetById(int productid)
        {

            var product = _context.Products.Find(productid);

            return View(_mapper.Map<ProductViewModel>(product));

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
            ViewBag.DictionaryExpire = new Dictionary<string, int>()
            {
                { "1 Ay", 1},
                { "3 Ay", 3},
                { "6 Ay", 6},
                { "12 Ay", 12}
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new ColorSelectList() { Text = "Red", Value = "Red" },
                new ColorSelectList() { Text = "Blue", Value = "Blue" },
                new ColorSelectList() { Text = "Green", Value = "Green" }
            }, "Value", "Text");


            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel newProduct)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //throw new Exception();

                    _context.Products.Add(_mapper.Map<Product>(newProduct));

                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ürün veri tabanına kaydedildiği sırada bir hata meydana geldi. Lütfen daha sonra tekrar deneyin !");

                    ViewBag.DictionaryExpire = new Dictionary<string, int>()
                    {
                        { "1 Ay", 1},
                        { "3 Ay", 3},
                        { "6 Ay", 6},
                        { "12 Ay", 12}
                    };

                    ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
                    {
                        new ColorSelectList() { Text = "Red", Value = "Red" },
                        new ColorSelectList() { Text = "Blue", Value = "Blue" },
                        new ColorSelectList() { Text = "Green", Value = "Green" }
                    }, "Value", "Text");

                    return View();
                }
            }
            else
            {
                ViewBag.DictionaryExpire = new Dictionary<string, int>()
                {
                    { "1 Ay", 1},
                    { "3 Ay", 3},
                    { "6 Ay", 6},
                    { "12 Ay", 12}
                };

                ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
                {
                    new ColorSelectList() { Text = "Red", Value = "Red" },
                    new ColorSelectList() { Text = "Blue", Value = "Blue" },
                    new ColorSelectList() { Text = "Green", Value = "Green" }
                }, "Value", "Text");

                return View();
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);

            ViewBag.ExpireValue = product.Expire;
            ViewBag.DictionaryExpire = new Dictionary<string, int>()
            {
                { "1 Ay", 1},
                { "3 Ay", 3},
                { "6 Ay", 6},
                { "12 Ay", 12}
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new ColorSelectList() { Text = "Red", Value = "Red" },
                new ColorSelectList() { Text = "Blue", Value = "Blue" },
                new ColorSelectList() { Text = "Green", Value = "Green" }
            }, "Value", "Text", product.Color);

            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel updateProduct)
        {
            if (ModelState.IsValid){
                _context.Products.Update(_mapper.Map<Product>(updateProduct));
                _context.SaveChanges();

                TempData["status"] = "Ürün başarıyla güncellendi.";

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ExpireValue = updateProduct.Expire;
                    ViewBag.DictionaryExpire = new Dictionary<string, int>()
                {
                    { "1 Ay", 1},
                    { "3 Ay", 3},
                    { "6 Ay", 6},
                    { "12 Ay", 12}
                };

                    ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
                {
                    new ColorSelectList() { Text = "Red", Value = "Red" },
                    new ColorSelectList() { Text = "Blue", Value = "Blue" },
                    new ColorSelectList() { Text = "Green", Value = "Green" }
                }, "Value", "Text", updateProduct.Color);

                return View();
            }
        }
    }
}
