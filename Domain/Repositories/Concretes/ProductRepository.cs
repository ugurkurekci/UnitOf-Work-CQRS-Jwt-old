using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Abstraction;
using Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Concretes;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(DbContext context, IMapper mapper) : base(context, mapper) { }

}