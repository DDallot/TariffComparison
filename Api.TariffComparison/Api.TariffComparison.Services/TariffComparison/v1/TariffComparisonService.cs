using Api.TariffComparison.Services.Domain.TariffComparison.v1;
using Api.TariffComparison.Services.Domain.TariffComparison.v1.Models;
namespace Api.TariffComparison.Services.TariffComparison.v1;

public class TariffComparisonService : ITariffComparisonService
{
    private readonly ITariffFactory _tariffFactory;

    public TariffComparisonService(ITariffFactory tariffFactory)
    {
        _tariffFactory = tariffFactory ?? throw new ArgumentNullException(nameof(tariffFactory));
    }

    public async Task<List<TariffComparisonResult>> CompareTariffsAsync(int consumptionKwh)
    {
        var tariffs = await _tariffFactory.GetElectricityTariffsAsync();

        var result = (
            from tariff in tariffs let annualCost = tariff.TariffCalculator.CalculateAnnualCosts(consumptionKwh)
            orderby annualCost ascending
            select new TariffComparisonResult { TariffName = tariff.Name, AnnualCost = annualCost }
        ).ToList();

        return result;
    }
}