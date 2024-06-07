using System.Linq.Expressions;

namespace MyShop.Entites.Repositers
{
    public interface IGenericRepositery<T> where T : class   // for any calss or Entity
    {

        IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? Includeword = null);
        T GetFirstOrDefault(Expression<Func<T, bool>>? predicate = null, string? Includeword = null);

        void Add(T Entity);

        void Remove(T Entity);

        void RemoveRange(IEnumerable<T> entites);


    }
}
