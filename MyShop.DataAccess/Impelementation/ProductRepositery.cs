using MyShop.DataAccess.Data;
using MyShop.Entites.Models;
using MyShop.Entites.Repositers;

namespace MyShop.DataAccess.Impelementation
{
    public class ProductRepositery : GenericRepositery<Product>, IProductRepositery
    {
        private readonly ApplicationDbContext _context;

        public ProductRepositery(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void UpdateProduct(Product product)
        {
            var ProductInDb = _context.Products.FirstOrDefault(x => x.id == product.id);
            if (ProductInDb != null)
            {
                ProductInDb.name = product.name;
                ProductInDb.description = product.description;
                ProductInDb.price = product.price;
                ProductInDb.img = product.img;
                ProductInDb.categoryId = product.categoryId;

            }
        }
    }
}
