using MyShop.Entites.Models;

namespace MyShop.Entites.Repositers
{
    public interface ICategoryRepositery : IGenericRepositery<Category>
    {
        public void UpdateCategory(Category category);
    }
}
