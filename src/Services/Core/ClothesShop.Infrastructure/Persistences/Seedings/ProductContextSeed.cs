using System.ComponentModel.DataAnnotations;
using System.Reflection;
using BuildingBlock.Shared.Enums.Product;
using Clothes.Domain.Entities;
using Clothes.Domain.Extensions;
using ILogger = Serilog.ILogger;

namespace Clothes.Infrastructure.Persistences.Seedings;

public class ProductContextSeed
{
    public static  async Task SeedProductAsync(ApplicationDbContext context, ILogger logger, CancellationToken cancellationToken = default)
    {
        //check data in product table
        //if not any, seed data into this
        if (!context.Products.Any())
        {
            context.AddRange(GetCatalogProducts());
            await context.SaveChangesAsync(cancellationToken);
            logger.Information("Seeded data for Product DB associated with context {DbContextName}",
                nameof(ApplicationDbContext));
        }
    }
  
    private static IEnumerable<Product> GetCatalogProducts()
    {
        return
        [
            new Product
            {
                No = "Lotus",
                Name = "Esprit",
                Summary = "Nondisplaced fracture of greater trochanter of right femur",
                Description = "Nondisplaced fracture of greater trochanter of right femur",
                Price = (decimal)177940.49,
                Currency = ECurrency.Vnd.GetDisplayName(),
                Stock = true,
                DefaultImage = string.Empty
            }.ModifyBrand(1).ModifyCategory(1),
            
            new Product
            {
                No = "Cadillac",
                Name = "CTS",
                Summary = "Carbuncle of trunk",
                Description = "Carbuncle of trunk",
                Price = (decimal)114728.21,
                Currency = ECurrency.Vnd.GetDisplayName(),
                Stock = true,
                DefaultImage = string.Empty,
            }.ModifyBrand(1).ModifyCategory(1),
        ];
    }
}
