using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureImplementation.Clerk
{
    public class ClerkContext : DbContext
    {
        public ClerkContext(DbContextOptions<ClerkContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ClerkEntity> ClerkEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClerkConfiguration).Assembly);
        }
    }
}
