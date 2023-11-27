namespace Api.TariffComparison.Contracts.Common;

public class ItemResult<T> : NoResult
{
    public T Item { get; set; }
}