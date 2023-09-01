using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
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
        
        public async Task<IViewComponentResult> InvokeAsync(int type)
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

            if (type == 1)
            {
                return View("FirstType",productsList);
            }
            else
            {
                return View("SecondType", productsList);
            }
        }
    }
}
