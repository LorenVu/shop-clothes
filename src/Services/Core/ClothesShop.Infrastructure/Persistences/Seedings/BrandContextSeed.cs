using Clothes.Domain.Entities;
using Serilog;

namespace Clothes.Infrastructure.Persistences.Seedings;

public static class BrandContextSeed
{
    public static  async Task SeedBrandAsync(ApplicationDbContext context, ILogger logger, CancellationToken cancellationToken = default)
    {
        //check data in brand table
        //if not any, seed data into this
        if (!context.Brands.Any())
        {
            context.AddRange(GetBrands());
            await context.SaveChangesAsync(cancellationToken);
            logger.Information("Seeded data for Brand DB associated with context {DbContextName}",
                nameof(ApplicationDbContext));
        }
    }
  
    private static IEnumerable<Brand> GetBrands()
    {
        return
        [
            new Brand
            {
                Name = "Apple"
            },
            
            new Brand
            {
                Name = "Samsung"
            }
        ];
    }
}