using Clothes.Domain.Entities;
using Serilog;

namespace Clothes.Infrastructure.Persistences.Seedings;

public class CategoryContextSeed
{
    public static async Task SeedCategoryAsync(ApplicationDbContext context, ILogger logger,
        CancellationToken cancellationToken = default)
    {
        //check data in product table
        //if not any, seed data into this
        if (!context.Categories.Any())
        {
            context.AddRange(GetCategories());
            await context.SaveChangesAsync(cancellationToken);
            logger.Information("Seeded data for Product DB associated with context {DbContextName}",
                nameof(ApplicationDbContext));
        }
    }
    
    private static IEnumerable<Category> GetCategories()
    {
        return
        [
            new Category("Car", "Car", "", 0, 0),
            new Category("Cadillac", "Cadillac", "", 0, 1),
        ];
    }
    
}