using Microsoft.EntityFrameworkCore;
using PaoDuro.Domain.Entities;
using PaoDuro.Domain.Repositories.Despesas;

namespace PaoDuro.Infrastructure.DataAccess.Repositories;

//internal para que o projeto de API nao enxergue essa classe, ela seja vista apenas dentro de infrastructure
internal class DespesasRepository : IDespesasReadOnlyRepository, IDespesasWriteOnlyRepository, IDespesasUpdateOnlyRepository
{
    private readonly PaoDuroDbContext _dbContext;
    public DespesasRepository(PaoDuroDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task Add(Despesa despesa)
    {
        await _dbContext.Despesas.AddAsync(despesa);
    }

    public async Task<List<Despesa>> GetAll()
    {
        return await _dbContext.Despesas.AsNoTracking().ToListAsync();
    }

    async Task<Despesa?> IDespesasReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.Despesas.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }

    async Task<Despesa?> IDespesasUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Despesas.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Despesas.FirstOrDefaultAsync(e => e.Id == id);

        if (result is null)
        {
            return false;
        }

        _dbContext.Despesas.Remove(result);

        return true;
    }

    public void Update(Despesa despesa)
    {
        _dbContext.Despesas.Update(despesa);
    }
}
