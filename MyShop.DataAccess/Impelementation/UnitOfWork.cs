using MyShop.DataAccess.Data;
using MyShop.Entites.Repositers;

namespace MyShop.DataAccess.Impelementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepositery Category { get; private set; }

        public IProductRepositery Product { get; private set; }


        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepositery(context);
            Product = new ProductRepositery(context);


        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
