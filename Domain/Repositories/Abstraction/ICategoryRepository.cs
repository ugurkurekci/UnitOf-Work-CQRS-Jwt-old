using Domain.Entities;
using Domain.Repositories.Base;

namespace Domain.Repositories.Abstraction;
public interface ICategoryRepository : IKeyRepositoryBase<Category>
{

    Category GetByName(string name);

}