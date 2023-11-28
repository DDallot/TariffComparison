using Api.TariffComparison.Services.Domain.TariffComparisons.v1;

namespace Api.TariffComparison.Services.TariffComparisons.v1.Tariffs;

public class PackagedTariff : ITariffCalculator
{
    private readonly decimal _additionalKwhCost;
    private readonly decimal _baseCost;
    private readonly int _includedKwh;

    public PackagedTariff(decimal baseCost, int includedKwh, decimal additionalKwhCost)
    {
        _baseCost = baseCost;
        _includedKwh = includedKwh;
        _additionalKwhCost = additionalKwhCost;
    }

    public decimal CalculateAnnualCosts(int consumptionKwh)
    {
        var annualCost = _baseCost;

        if (consumptionKwh > _includedKwh)
        {
            var additionalKwh = consumptionKwh - _includedKwh;
            annualCost += additionalKwh * (_additionalKwhCost / 100);
        }

        return annualCost;
    }
}