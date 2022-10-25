using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Base;


public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{

    protected DbContext _context;

    private readonly DbSet<T> _dbset;

    public RepositoryBase(DbContext context)
    {
        _context = context;
        _dbset = _context.Set<T>();

    }

    public IList<T> GetAll()
    {
        return _dbset.AsNoTracking().ToList();
    }

    public void Add(T entity)
    {
        _dbset.Add(entity);
    }

    public void Update(T entity)
    {
        _dbset.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbset.Remove(entity);
    }

}