using Domain.Domains;

namespace Infrastructure.Repositories
{
    public interface IClerkRepository : IRepository<ClerkEntity>
    {
        ClerkEntity GetByUserNameAndPassword(string userName, string password);
    }
}
