using Api.TariffComparison.Services.Domain.TariffComparison.v1;

namespace Api.TariffComparison.Services.TariffComparison.v1.Tariffs;

public class PackagedTariff : ITariffCalculator
{
    private readonly decimal _baseCost;
    private readonly int _includedKwh;
    private readonly decimal _additionalKwhCost;

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
            annualCost += additionalKwh * (_additionalKwhCost/100);
        }

        return annualCost;
    }
}