using PaoDuro.Domain.Repositories;

namespace PaoDuro.Infrastructure.DataAccess;

internal class UnitOfWork : IUnitOfWork
{

    private readonly PaoDuroDbContext _dbContext;
    public UnitOfWork(PaoDuroDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }
}
