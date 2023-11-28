using Api.TariffComparison.Contracts.Common;
using Api.TariffComparison.Contracts.v1.Electricities;
using Api.TariffComparison.Contracts.v1.Electricities.Response;
using Api.TariffComparison.Controllers.Electricities.v1.Extensions;
using Api.TariffComparison.Services.Domain.TariffComparisons.v1;

namespace Api.TariffComparison.Controllers.Electricities.v1;

public class Electricity : IElectricity
{
    private readonly ILogger<Electricity> _logger;
    private readonly ITariffComparisonService _tariffComparisonService;

    public Electricity(ITariffComparisonService tariffComparisonService, ILogger<Electricity> logger)
    {
        _tariffComparisonService =
            tariffComparisonService ?? throw new ArgumentNullException(nameof(tariffComparisonService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ListResult<ComparisonResponse>> CompareAsync(int consumptionKwh)
    {
        try
        {
            var comparisons = await _tariffComparisonService.CompareTariffsAsync(consumptionKwh);
            var result = comparisons.Convert();

            return await Task.FromResult(new ListResult<ComparisonResponse> { Items = result });
        }
        catch (Exception ex)
        {
            _logger.LogError("Error on Object {0}, method {1}, exception {2}", nameof(Electricity),
                nameof(CompareAsync), ex.Message);
            return new ListResult<ComparisonResponse>
            {
                HasError = true,
                Error = "Error getting the Comparisons."
            };
        }
    }
}