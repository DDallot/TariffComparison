using Api.TariffComparison.Services.Domain.TariffComparisons.v1;

namespace Api.TariffComparison.Services.TariffComparisons.v1.Tariffs;

public class BasicElectricityTariff : ITariffCalculator
{
    private readonly decimal _baseCost;
    private readonly decimal _additionalKwhCost;
    public BasicElectricityTariff(decimal baseCost, decimal additionalKwhCost)
    {
        _baseCost = baseCost;
        _additionalKwhCost = additionalKwhCost;
    }

    public decimal CalculateAnnualCosts(int consumptionKwh)
    {
        var baseCostPerYear = _baseCost * 12;
        var consumptionCost = consumptionKwh * (_additionalKwhCost /100);

        return baseCostPerYear + consumptionCost;
    }
}