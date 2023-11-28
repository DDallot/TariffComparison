namespace Api.TariffComparison.Contracts.v1.Electricities.Response;

public class ComparisonResponse
{
    public string TariffName { get; set; }
    public decimal AnnualCost { get; set; }
}