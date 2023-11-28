namespace Api.TariffComparison.Services.Domain.TariffComparisons.v1;

public interface ITariffCalculator
{
    decimal CalculateAnnualCosts(int consumptionKwh);
}