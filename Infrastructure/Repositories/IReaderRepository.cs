using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public interface IReaderRepository<T>
    {
        T Get(long id);
        IEnumerable<T> GetByIds(IEnumerable<long> ids);
        IEnumerable<T> GetAll();
    }
}
