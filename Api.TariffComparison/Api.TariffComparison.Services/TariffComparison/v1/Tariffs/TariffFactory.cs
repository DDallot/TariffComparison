using Api.TariffComparison.Services.Domain.TariffComparison.v1;
using Api.TariffComparison.Services.Domain.TariffComparison.v1.Models;
using Api.TariffComparison.Services.Domain.TariffProviderService.v1;
using Api.TariffComparison.Services.TariffComparison.v1.Extensions;
using Newtonsoft.Json;

namespace Api.TariffComparison.Services.TariffComparison.v1.Tariffs;

public class TariffFactory : ITariffFactory
{
    private readonly ITariffProviderService _tariffProviderService;

    public TariffFactory(ITariffProviderService tariffProviderService)
    {
        _tariffProviderService = tariffProviderService ?? throw new ArgumentNullException(nameof(tariffProviderService));
    }

    public async Task<IEnumerable<ElectricityTariff>> GetElectricityTariffsAsync()
    {
        var jsonProducts = await _tariffProviderService.GetProductsAsync();

        var electricityPrices = JsonConvert.DeserializeObject<IEnumerable<ElectricityPrice>>(jsonProducts) ?? new List<ElectricityPrice>();

        return electricityPrices.Select(electricityPrice => electricityPrice.Type switch
        {
            1 => electricityPrice.CreateBasicElectricityTariff(),
            2 => electricityPrice.CreatePackagedTariff(),
            _ => throw new Exception($"Electricity Type {electricityPrice.Type} not found.")
        })
        .ToList();
    }
}