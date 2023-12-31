﻿using Microsoft.EntityFrameworkCore;

namespace Api.TariffComparison.Database.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApiContext _dbContext;

    public Repository(ApiContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public T? GetById(int id) => _dbContext.Set<T>().Find(id);
    public IQueryable<T> List() => _dbContext.Set<T>().AsQueryable();
    public void Delete(T value) => _dbContext.Set<T>().Remove(value);
    public void Add(T value) => _dbContext.Set<T>().Add(value);
    public void Edit(T value) => _dbContext.Entry(value).State = EntityState.Modified;

    public async Task SaveAsync(IEnumerable<T> entitiesToCleanTracking)
    {
        await _dbContext.SaveChangesAsync();
        foreach (var entity in entitiesToCleanTracking) _dbContext.Entry(entity).State = EntityState.Detached;
    }

    public async Task SaveAsync(T entitiesToCleanTracking)
    {
        await _dbContext.SaveChangesAsync();
        _dbContext.Entry(entitiesToCleanTracking).State = EntityState.Detached;
    }
}