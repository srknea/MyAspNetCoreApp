using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Views.Shared.ViewComponents
{
    public class ProductListViewComponents : ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductListViewComponents(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> Invoke()
        {
            var products = _context.Products
                .OrderByDescending(p => p.Id)
                .Select(x => new ProductComponentViewModel()
                {
                    Name = x.Name,
                    Description = x.Description
                })
                .ToList();

            ViewBag.productListPartialViewModel = new ProductListComponentViewModel()
            {
                Products = products
            };
            return View();
        }
    }
}
