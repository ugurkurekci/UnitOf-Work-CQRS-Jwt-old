using Domain.Entities;
using Domain.Repositories.Base;
using System.Linq.Expressions;

namespace Domain.Repositories.Abstraction;

public interface IProductRepository
{
    Task<IReadOnlyList<Product>> GetAll();

    Task<IReadOnlyList<Product>> GetAllByFilter(Expression<Func<Product, bool>> filter);

    Task<Product> GetByFilter(Expression<Func<Product, bool>> filter);

    Task Add(Product entity);

    Task Update(Product entity);

    Task Delete(Product entity);
}