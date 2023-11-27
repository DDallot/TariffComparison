namespace Api.TariffComparison.Database.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Type { get; set; }
    public int? IncludedKwh { get; set; }
    public decimal? BaseCost { get; set; }
    public decimal? AdditionalKwhCost { get; set; }

    public ProductEntity()
    {

    }
    public ProductEntity(int id, string name, int type, int? includedKwh, decimal? baseCost, decimal? additionalKwhCost)
    {
        Id = id;
        Name = name;
        Type = type;
        IncludedKwh = includedKwh;
        BaseCost = baseCost;
        AdditionalKwhCost = additionalKwhCost;
    }
}