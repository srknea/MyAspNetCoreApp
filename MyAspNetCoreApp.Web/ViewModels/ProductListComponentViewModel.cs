namespace MyAspNetCoreApp.Web.ViewModels
{
    public class ProductListComponentViewModel
    {
        public List<ProductComponentViewModel> Products { get; set; }
    }

    public class ProductComponentViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
