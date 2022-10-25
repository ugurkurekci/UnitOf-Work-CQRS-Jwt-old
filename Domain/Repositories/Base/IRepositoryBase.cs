namespace Domain.Repositories.Base;


public interface IRepositoryBase<T> where T : class
{

    IList<T> GetAll();

    void Add(T entity);

    void Update(T entity);

    void Delete(T entity);

}