using Api.TariffComparison.Services.Domain.TariffProviders.v1;
using Api.TariffComparison.Services.Domain.TariffProviders.v1.Models;
using Newtonsoft.Json;

namespace Api.TariffComparison.Services.TariffProviders.v1;

public class TariffProviderMockService : ITariffProviderService
{
    public Task<string> GetProductsAsync()
    {
        var products = new List<Product>
        {
            new()
            {
                Name = "Product A",
                Type = 1,
                BaseCost = 5,
                AdditionalKwhCost = 22
            },
            new()
            {
                Name = "Product B",
                Type = 2,
                IncludedKwh = 4000,
                BaseCost = 800,
                AdditionalKwhCost = 30
            }
        };

        var jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        var json = JsonConvert.SerializeObject(products,Formatting.None, jsonSettings);

        return Task.FromResult(json);
    }
}