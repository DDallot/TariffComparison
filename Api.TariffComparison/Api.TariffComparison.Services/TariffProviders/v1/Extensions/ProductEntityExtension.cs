using Api.TariffComparison.Database.Entities;
using Api.TariffComparison.Services.Domain.TariffProviders.v1.Models;

namespace Api.TariffComparison.Services.TariffProviders.v1.Extensions;

public static class ProductEntityExtension
{
    public static Product FromEntity(this ProductEntity entity)
    {
        return new Product
        {
            Type = entity.Id,
            Name = entity.Name,
            BaseCost = entity.BaseCost,
            AdditionalKwhCost = entity.AdditionalKwhCost,
            IncludedKwh = entity.IncludedKwh
        };
    }
}