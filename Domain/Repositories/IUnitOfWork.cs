using Domain.Repositories.Abstraction;

namespace Domain;

public interface IUnitOfWork : IDisposable
{

    public IProductRepository ProductRepository { get; }

    public ICategoryRepository CategoryRepository { get; }

    public int Complete();

}