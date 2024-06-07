using MyShop.DataAccess.Data;
using MyShop.Entites.Models;
using MyShop.Entites.Repositers;

namespace MyShop.DataAccess.Impelementation
{
    public class CategoryRepositery : GenericRepositery<Category>, ICategoryRepositery
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepositery(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void UpdateCategory(Category category)
        {
            var CategoryInDb = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
            if (CategoryInDb != null)
            {
                CategoryInDb.Name = category.Name;
                CategoryInDb.Description = category.Description;
                CategoryInDb.CreatedAdd = DateTime.Now;

            }
        }
    }
}
