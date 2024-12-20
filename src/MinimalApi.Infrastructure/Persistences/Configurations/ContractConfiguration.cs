using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalApi.Domain.Entities;
using MinimalApi.Domain.Enums;

namespace MinimalProject.Infrastructure.Persistences.Configurations;

public class ContractConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.Property(c => c.IsActive)
            .HasDefaultValue(EStatusBase.Active);
            
        builder.Property(c => c.IsDeleted)
            .HasDefaultValue(false);
    }
}