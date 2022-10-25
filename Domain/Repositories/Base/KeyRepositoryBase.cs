using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Base;


public class KeyRepositoryBase<T> : RepositoryBase<T>, IKeyRepositoryBase<T> where T : class
{

    public KeyRepositoryBase(DbContext context) : base(context) { }

    public T GetByKey(string key)
    {
        return _context.Set<T>().Find(key);
    }

}