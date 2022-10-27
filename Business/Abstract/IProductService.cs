using Domain.Entities;

namespace Business.Abstract;

public interface IProductService
{

    int Add(Product product);

    Task<IReadOnlyList<Product>> GetAll();

    Task<Product> GetById(int id);

}