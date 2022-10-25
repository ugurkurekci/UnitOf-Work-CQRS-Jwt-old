using Domain.Data.EFCore;
using Domain.Entities;
using Domain.Repositories.Abstraction;
using Domain.Repositories.Base;

namespace Domain.Repositories.Concretes;

public class CategoryRepository : KeyRepositoryBase<Category>, ICategoryRepository
{

    private readonly ProjectDataContext _projectDataContext;

    public CategoryRepository(ProjectDataContext projectDataContext) : base(projectDataContext)
    {
        _projectDataContext = projectDataContext;
    }

    public Category GetByName(string name)
    {
        return _projectDataContext.Category.Find(name);
    }

}