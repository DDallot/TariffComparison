using Api.TariffComparison.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.TariffComparison.Database;
public class ApiContext : DbContext
{
    public DbSet<ProductEntity> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "InMemoryTariffComparison");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductEntity>().HasData(
            new ProductEntity { Id = 1, Name = "Product A", Type = 1, BaseCost = 5, AdditionalKwhCost = 22 },
            new ProductEntity { Id = 2, Name = "Product B", Type = 2, IncludedKwh = 4000, BaseCost = 800, AdditionalKwhCost = 30 }
        );
    }
}