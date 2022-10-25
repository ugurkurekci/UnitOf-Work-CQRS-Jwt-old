using Domain.Data.EFCore;
using Domain.Entities;
using Domain.Repositories.Abstraction;
using Domain.Repositories.Base;

namespace Domain.Repositories.Concretes;


public class ProductRepository : DefaultRepositoryBase<Product>, IProductRepository
{

    private readonly ProjectDataContext _projectDataContext;

    public ProductRepository(ProjectDataContext projectDataContext) : base(projectDataContext)
    {
        _projectDataContext = projectDataContext;
    }

    public Product GetByStock(int stock)
    {
        return _projectDataContext.Product.Find(stock);
    }

}