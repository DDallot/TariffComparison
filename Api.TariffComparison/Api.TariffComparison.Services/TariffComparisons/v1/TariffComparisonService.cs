using Api.TariffComparison.Services.Domain.TariffComparisons.v1;
using Api.TariffComparison.Services.Domain.TariffComparisons.v1.Models;

namespace Api.TariffComparison.Services.TariffComparisons.v1;

public class TariffComparisonService : ITariffComparisonService
{
    private readonly ITariffFactory _tariffProductFactory;

    public TariffComparisonService(ITariffFactory tariffProductFactory)
    {
        _tariffProductFactory = tariffProductFactory ?? throw new ArgumentNullException(nameof(tariffProductFactory));
    }

    public async Task<List<TariffComparisonResult>> CompareTariffsAsync(int consumptionKwh)
    {
        var tariffs = await _tariffProductFactory.GetElectricityTariffsAsync();

        var result = (
            from tariff in tariffs
            let annualCost = tariff.TariffCalculator.CalculateAnnualCosts(consumptionKwh)
            orderby annualCost
            select new TariffComparisonResult { TariffName = tariff.Name, AnnualCost = annualCost }
        ).ToList();

        return result;
    }
}