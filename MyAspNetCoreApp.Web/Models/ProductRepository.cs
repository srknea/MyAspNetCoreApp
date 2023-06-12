namespace MyAspNetCoreApp.Web.Models
{
    public class ProductRepository
    {
        private static List<Product> _products;

        public List<Product> GetAll() => _products;

        public void Add(Product newProduct) => _products.Add(newProduct);

        public void Remove(int id) {

            var hasProduct = _products.FirstOrDefault(p => p.Id == id);

            if (hasProduct == null)
            {
                throw new Exception($"Bu id[{id}]'ye sahip ürün bulunamamaktadır.");
            }

            _products.Remove(hasProduct);
        }
        
        public void Update(Product updateProduct)
        {
            var hasProduct = _products.FirstOrDefault(p => p.Id == updateProduct.Id);
            if (hasProduct == null)
            {
                throw new Exception($"Bu id[{updateProduct.Id}]'ye sahip ürün bulunamamaktadır.");
            }
            hasProduct.Name = updateProduct.Name;
            hasProduct.Price = updateProduct.Price;
            hasProduct.Stock = updateProduct.Stock;

            var index = _products.FindIndex(p => p.Id == updateProduct.Id);
            _products[index] = hasProduct;
        }

    }
}
