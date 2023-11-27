namespace Api.TariffComparison.Contracts.Common;

public class ListResult<T> : NoResult
{
    public List<T> Items { get; set; }
}