namespace Api.TariffComparison.Services.Domain.TariffProviderService.v1;

public interface ITariffProviderService
{
    Task<string> GetProductsAsync();
}