using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Base;


public class DefaultRepositoryBase<T> : RepositoryBase<T>, IDefaultRepositoryBase<T> where T : class
{

    public DefaultRepositoryBase(DbContext context) : base(context) { }

    public T GetByID(int id)
    {
        return _context.Set<T>().Find(id);
    }

}