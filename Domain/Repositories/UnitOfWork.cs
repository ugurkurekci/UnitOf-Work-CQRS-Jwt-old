using Domain.Data.EFCore;
using Domain.Repositories.Abstraction;
using Domain.Repositories.Concretes;

namespace Domain;
public class UnitOfWork : IUnitOfWork
{
    public readonly ProjectDataContext _projectDataContext;

    public UnitOfWork(ProjectDataContext projectDataContext)
    {
        _projectDataContext = projectDataContext;
        ProductRepository = new ProductRepository(_projectDataContext);
        CategoryRepository = new CategoryRepository(_projectDataContext);
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
