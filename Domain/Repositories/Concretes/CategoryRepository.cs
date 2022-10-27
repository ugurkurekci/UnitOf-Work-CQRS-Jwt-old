using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Abstraction;
using Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Concretes;

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{

    public CategoryRepository(DbContext context, IMapper mapper) : base(context, mapper) { }

}