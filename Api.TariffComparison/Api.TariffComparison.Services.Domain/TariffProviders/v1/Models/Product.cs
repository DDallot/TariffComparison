namespace Api.TariffComparison.Services.Domain.TariffProviders.v1.Models;

public class Product
{
    public string Name { get; set; }
    public int Type { get; set; }
    public int? IncludedKwh { get; set; }
    public decimal? BaseCost { get; set; }
    public decimal? AdditionalKwhCost { get; set; }
}