namespace Api.TariffComparison.Services.Domain.TariffComparisons.v1.Models;

public class ElectricityTariff
{
    public string Name { get; set; }
    public int Type { get; set; }
    public ITariffCalculator TariffCalculator { get; set; }
}