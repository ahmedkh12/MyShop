namespace MyShop.Entites.Repositers
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepositery Category { get; }

        IProductRepositery Product { get; }

        int Complete();
    }
}
