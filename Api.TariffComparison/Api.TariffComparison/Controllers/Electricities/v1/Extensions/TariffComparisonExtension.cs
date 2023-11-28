using Api.TariffComparison.Contracts.v1.Electricities.Response;
using Api.TariffComparison.Services.Domain.TariffComparisons.v1.Models;

namespace Api.TariffComparison.Controllers.Electricities.v1.Extensions;

public static class TariffComparisonExtension
{
    public static List<ComparisonResponse> Convert(this List<TariffComparisonResult> inputs)
    {
        return inputs.Select(t => t.Convert()).ToList();
    }

    public static ComparisonResponse Convert(this TariffComparisonResult input)
    {
        return new ComparisonResponse
        {
            TariffName = input.TariffName,
            AnnualCost = input.AnnualCost
        };
    }
}