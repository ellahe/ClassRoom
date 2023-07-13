using Domain.Domains;

namespace Infrastructure.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        long Add(T entity);
        void Update(T entity);
        T Get(long id);
    }

    public interface ICrudRepository<T> : IRepository<T> where T : Entity
    {
        void Delete(T entity);

        void DeleteById(long id);
    }
}
