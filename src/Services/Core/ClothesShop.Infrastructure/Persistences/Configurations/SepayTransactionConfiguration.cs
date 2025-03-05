using Clothes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clothes.Infrastructure.Persistences.Configurations;

public class SepayTransactionConfiguration : IEntityTypeConfiguration<SepayTransaction>
{
    public void Configure(EntityTypeBuilder<SepayTransaction> builder)
    {
        builder.ToTable("transactions");

        builder.HasIndex(x => x.AccountNumber)
            .HasDatabaseName("ix_transactions_accountNumber")
            .HasMethod("gin")
            .HasAnnotation("Npgsql:IndexOps", "gin_trgm_ops"); ;
    }
}