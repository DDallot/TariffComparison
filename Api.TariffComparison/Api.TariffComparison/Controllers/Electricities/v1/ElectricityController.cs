using Api.TariffComparison.Contracts.Common;
using Api.TariffComparison.Contracts.v1.Electricities;
using Api.TariffComparison.Contracts.v1.Electricities.Response;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Api.TariffComparison.Controllers.Electricities.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ElectricityController : ControllerBase, IElectricity
{
    private readonly IElectricity _tariff;

    public ElectricityController(IElectricity tariff)
    {
        _tariff = tariff ?? throw new ArgumentNullException(nameof(tariff));
    }

    [HttpGet("compare")]
    public async Task<ListResult<TariffComparisonResponse>> CompareAsync([FromQuery]int consumptionKwh)
    {
        return await _tariff.CompareAsync(consumptionKwh);
    }
}