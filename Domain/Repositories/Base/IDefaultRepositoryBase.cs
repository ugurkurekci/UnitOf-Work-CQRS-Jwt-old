namespace Domain.Repositories.Base;


public interface IDefaultRepositoryBase<T> : IRepositoryBase<T> where T : class
{

    T GetByID(int id);

}