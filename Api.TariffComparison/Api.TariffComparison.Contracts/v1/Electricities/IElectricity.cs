using Api.TariffComparison.Contracts.Common;
using Api.TariffComparison.Contracts.v1.Electricities.Response;

namespace Api.TariffComparison.Contracts.v1.Electricities;

public interface IElectricity
{
    Task<ListResult<TariffComparisonResponse>> CompareAsync(int consumptionKwh);
}