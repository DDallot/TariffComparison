using Api.TariffComparison.Services.Domain.TariffComparison.v1.Models;

namespace Api.TariffComparison.Services.Domain.TariffComparison.v1;

public interface ITariffFactory
{
    Task<IEnumerable<ElectricityTariff>> GetElectricityTariffsAsync();
}