using Domain.Entities;
using Domain.Repositories.Base;

namespace Domain.Repositories.Abstraction;


public interface IProductRepository : IDefaultRepositoryBase<Product>
{

    Product GetByStock(int stock);

}