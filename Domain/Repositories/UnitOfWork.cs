using Domain.Data.EFCore;
using Domain.Repositories.Abstraction;

namespace Domain;
public class UnitOfWork : IUnitOfWork
{
    public readonly ProjectDataContext _projectDataContext;

    public UnitOfWork(
        ProjectDataContext projectDataContext,
        IProductRepository productRepository,
        ICategoryRepository categoryRepository)
    {
        _projectDataContext = projectDataContext;
        CategoryRepository = categoryRepository;
        ProductRepository = productRepository;
    }

    public IProductRepository ProductRepository { get; private set; }

    public ICategoryRepository CategoryRepository { get; private set; }

    public int Complete()
    {
        return _projectDataContext.SaveChanges();
    }

    public void Dispose()
    {
        _projectDataContext.Dispose();
    }

}
