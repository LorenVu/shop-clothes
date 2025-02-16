using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Infrastructure.Persistences.Data.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transactions");

        builder.HasIndex(x => x.AccountNumber)
            .HasDatabaseName("IX_Transactions_AccountNumber")
            .HasMethod("gin")
            .HasAnnotation("Npgsql:IndexOps", "gin_trgm_ops");;
    }
}