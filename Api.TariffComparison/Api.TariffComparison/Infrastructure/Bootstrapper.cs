using Api.TariffComparison.Contracts.v1.Electricities;
using Api.TariffComparison.Controllers.Electricities.v1;
using Api.TariffComparison.Database.Repositories;
using Api.TariffComparison.Services.Domain.TariffComparisons.v1;
using Api.TariffComparison.Services.Domain.TariffProviders.v1;
using Api.TariffComparison.Services.TariffComparisons.v1;
using Api.TariffComparison.Services.TariffComparisons.v1.Tariffs;
using Api.TariffComparison.Services.TariffProviders.v1;

namespace Api.TariffComparison.Infrastructure;

public static class Bootstrapper
{
    public static IServiceProvider Initialize(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddScoped<IElectricity, Electricity>();

        // Services
        serviceCollection.AddScoped<ITariffComparisonService, TariffComparisonService>();
        serviceCollection.AddScoped<ITariffFactory, TariffFactory>();
        serviceCollection.AddScoped<ITariffProviderService, TariffProviderService>();

        // Repository
        serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return serviceCollection.BuildServiceProvider();
    }
}