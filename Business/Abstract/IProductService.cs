using Domain.Entities;

namespace Business.Abstract;

public interface IProductService
{
    int Add(Product product);

    IList<Product> GetAll();

    Product GetById(int id);
}