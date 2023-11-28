using Api.TariffComparison.Database.Entities;
using Api.TariffComparison.Database.Repositories;
using Api.TariffComparison.Services.Domain.TariffProviders.v1;
using Api.TariffComparison.Services.TariffProviders.v1.Extensions;
using Newtonsoft.Json;

namespace Api.TariffComparison.Services.TariffProviders.v1;

public class TariffProviderService : ITariffProviderService
{
    private readonly IRepository<ProductEntity> _productRepository;

    public TariffProviderService(IRepository<ProductEntity> productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public Task<string> GetProductsAsync()
    {
        var products = _productRepository.List().Select(p => p.FromEntity()).ToList();


        var jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        var json = JsonConvert.SerializeObject(products, Formatting.None, jsonSettings);

        return Task.FromResult(json);
    }
}