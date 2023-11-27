using Api.TariffComparison.Services.Domain.TariffComparisons.v1.Models;

namespace Api.TariffComparison.Services.Domain.TariffComparisons.v1;

public interface ITariffFactory
{
    Task<IEnumerable<ElectricityTariff>> GetElectricityTariffsAsync();
}