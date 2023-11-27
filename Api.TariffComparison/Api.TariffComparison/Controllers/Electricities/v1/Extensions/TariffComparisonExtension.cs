using Api.TariffComparison.Contracts.v1.Electricities.Response;
using Api.TariffComparison.Services.Domain.TariffComparisons.v1.Models;

namespace Api.TariffComparison.Controllers.Electricities.v1.Extensions;

public static class TariffComparisonExtension
{
    public static List<TariffComparisonResponse> Convert(this List<TariffComparisonResult> inputs)
    {
        return inputs.Select(t => t.Convert()).ToList();
    }

    public static TariffComparisonResponse Convert(this TariffComparisonResult input)
    {
        return new TariffComparisonResponse
        {
            TariffName = input.TariffName,
            AnnualCost = input.AnnualCost
        };
    }
}