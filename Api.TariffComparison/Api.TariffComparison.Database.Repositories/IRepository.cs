namespace Api.TariffComparison.Database.Repositories;

public interface IRepository<T> where T : class
{
    T? GetById(int id);
    IQueryable<T> List();
    void Add(T value);
    void Edit(T value);
    void Delete(T value);
    Task SaveAsync(IEnumerable<T> entitiesToCleanTracking);
    Task SaveAsync(T entitiesToCleanTracking);
}