namespace Api.TariffComparison.Services.Domain.TariffProviders.v1;

public interface ITariffProviderService
{
    Task<string> GetProductsAsync();
}