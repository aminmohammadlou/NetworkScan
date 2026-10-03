using Data.Models;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Service.Repository;

public class Repo(NetworkScanDbContext dbContext)
{
    public async Task AddEntity<TEntity>(TEntity entity) where TEntity : class
    {
        await dbContext.Set<TEntity>().AddAsync(entity);
    }

    public void Remove<TEntity>(params TEntity[] entities) where TEntity : class
    {
        dbContext.Set<TEntity>().RemoveRange(entities);
    }

    public async Task SaveChanges()
    {
        await dbContext.SaveChangesAsync();
    }

    public async Task<UserModel[]> GetUsers()
    {
        return await dbContext.Users.ToArrayAsync();
    }

    public async Task<ComputerModel[]> GetComputers()
    {
        return await dbContext.Computers.ToArrayAsync();
    }
}
