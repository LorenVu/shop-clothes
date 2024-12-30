using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Infrastructure.Persistences;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<IdentityCustomer> IdentityCustomers { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Ward> Wards { get; set; }
    public DbSet<Partner> Partners { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Bank> Banks { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasIndex(c => c.FullName, "IX_Customer_FullName_Descending")
            .HasMethod("gin")
            .HasAnnotation("Npgsql:IndexOps", "gin_trgm_ops")
            .IsDescending();

        modelBuilder.Entity<Customer>()
            .HasIndex(c => c.EmailAddress, "IX_Customer_Email_Descending")
            .HasMethod("gin")
            .HasAnnotation("Npgsql:IndexOps", "gin_trgm_ops")
            .IsDescending();
        
        base.OnModelCreating(modelBuilder);
    }
}