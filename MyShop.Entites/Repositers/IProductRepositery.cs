using MyShop.Entites.Models;

namespace MyShop.Entites.Repositers
{
    public interface IProductRepositery : IGenericRepositery<Product>
    {
        public void UpdateProduct(Product product);
    }
}
