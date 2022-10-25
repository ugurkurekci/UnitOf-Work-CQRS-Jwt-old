namespace Domain.Repositories.Base;


public interface IKeyRepositoryBase<T> : IRepositoryBase<T> where T : class
{

    T GetByKey(string key);

}