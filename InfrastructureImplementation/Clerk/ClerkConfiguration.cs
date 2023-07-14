using Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureImplementation.Clerk
{
    public class ClerkConfiguration : IEntityTypeConfiguration<ClerkEntity>
    {
        public void Configure(EntityTypeBuilder<ClerkEntity> builder)
        {
            builder
                .Property(b => b.ID)
                .IsRequired();
        }
    }
}
