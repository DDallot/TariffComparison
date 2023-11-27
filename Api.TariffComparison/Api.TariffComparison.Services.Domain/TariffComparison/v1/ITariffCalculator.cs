namespace Api.TariffComparison.Services.Domain.TariffComparison.v1;

public interface ITariffCalculator
{
    decimal CalculateAnnualCosts(int consumptionKwh);
}
