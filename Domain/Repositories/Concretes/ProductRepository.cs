using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Data.EFCore;
using Domain.Entities;
using Domain.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Domain.Repositories.Concretes;

public class ProductRepository : IProductRepository
{
    private readonly ProjectDataContext _projectDataContext;
    private readonly IMapper _mapper;

    public ProductRepository(ProjectDataContext projectDataContext, IMapper mapper)
    {
        _projectDataContext = projectDataContext;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<Product>> GetAll()
    {
        return await _projectDataContext.Product.ProjectTo<Product>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<IReadOnlyList<Product>> GetAllByFilter(Expression<Func<Product, bool>> filter)
    {
        return await _projectDataContext.Product.ProjectTo<Product>(_mapper.ConfigurationProvider).Where(filter).ToListAsync();
    }

    public async Task<Product> GetByFilter(Expression<Func<Product, bool>> filter)
    {
        return await _projectDataContext.Product.ProjectTo<Product>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(filter);
    }

    public async Task Add(Product entity)
    {
        await _projectDataContext.Product.AddAsync(entity);
    }

    public async Task Update(Product entity)
    {
        _projectDataContext.Product.Update(entity);
        await Task.CompletedTask;
    }

    public async Task Delete(Product entity)
    {
        _projectDataContext.Product.Update(entity);
        await Task.CompletedTask;

    }
}