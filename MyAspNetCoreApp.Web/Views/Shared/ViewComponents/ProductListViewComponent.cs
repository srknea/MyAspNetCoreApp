using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Views.Shared.ViewComponents
{
    public class ProductListViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = _context.Products
                .OrderByDescending(p => p.Id)
                .Select(x => new ProductComponentViewModel()
                {
                    Name = x.Name,
                    Description = x.Description
                })
                .ToList();

            var productsList = new ProductListComponentViewModel()
            {
                Products = products
            };

            return View(productsList);
        }
    }
}
