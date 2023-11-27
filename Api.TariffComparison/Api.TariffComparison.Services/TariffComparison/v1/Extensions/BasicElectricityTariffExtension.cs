using Api.TariffComparison.Services.Domain.TariffComparison.v1.Models;
using Api.TariffComparison.Services.TariffComparison.v1.Tariffs;
namespace Api.TariffComparison.Services.TariffComparison.v1.Extensions;

public static class BasicElectricityTariffExtension
{
    public static ElectricityTariff CreateBasicElectricityTariff(this ElectricityPrice electricityPrice)
    {
        return new ElectricityTariff
        {
            Name = electricityPrice.Name,
            Type = electricityPrice.Type,
            TariffCalculator = new BasicElectricityTariff(
                electricityPrice.BaseCost ?? 0,
                electricityPrice.AdditionalKwhCost ?? 0)
        };
    }
}