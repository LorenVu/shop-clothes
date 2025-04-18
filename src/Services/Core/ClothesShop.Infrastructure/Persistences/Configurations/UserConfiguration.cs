using Clothes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clothes.Infrastructure.Persistences.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasQueryFilter(x => !x.IsDeleted);

        builder
            .HasIndex(c => c.FullName, "IX_Customer_FullName_Descending")
            .HasMethod("gin")
            .HasAnnotation("Npgsql:IndexOps", "gin_trgm_ops")
            .IsDescending();

        builder
            .HasIndex(c => c.EmailAddress, "IX_Customer_Email_Descending")
            .HasMethod("gin")
            .HasAnnotation("Npgsql:IndexOps", "gin_trgm_ops")
            .IsDescending();
    }
}