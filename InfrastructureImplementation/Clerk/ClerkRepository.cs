using System.Linq;
using Domain.Domains;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InfrastructureImplementation.Clerk
{
    public class ClerkRepository : IRepository<ClerkEntity>
    {
        private readonly ClerkContext _context;

        public ClerkRepository(ClerkContext context)
        {
            // context.Database.EnsureDeleted();
            context.Database.Migrate();
            _context = context;
        }

        public long Add(ClerkEntity user)
        {
            var added = _context.ClerkEntity.Add(user);
            _context.SaveChanges();
            return added.Entity.ID;
        }

        public ClerkEntity Get(long id)
        {
            return _context.ClerkEntity.FirstOrDefault(x => x.ID == id);
        }

        public void Update(ClerkEntity user)
        {
            ClerkEntity userInDb = _context.ClerkEntity.Find(user.ID);
            if (userInDb != null)
            {
                EntityEntry<ClerkEntity> ee = _context.Entry(user);
                ee.CurrentValues.SetValues(user);
            }
            _context.SaveChanges();
        }
    }
}
