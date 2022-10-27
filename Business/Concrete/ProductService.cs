using Business.Abstract;
using Domain;
using Domain.Entities;

namespace Business.Concrete;

public class ProductService : IProductService
{

    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public int Add(Product product)
    {
        _unitOfWork.ProductRepository.Add(product);
        _unitOfWork.Complete();
        return product.ID;
    }

    public Task<IReadOnlyList<Product>> GetAll()
    {
        return _unitOfWork.ProductRepository.GetAll();
    }

    public Task<Product> GetById(int id)
    {
        return _unitOfWork.ProductRepository.GetByFilter(x => x.ID == id);
    }

}