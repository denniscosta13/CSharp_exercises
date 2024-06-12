using PaoDuro.Domain.Entities;
using PaoDuro.Domain.Repositories.Despesas;

namespace PaoDuro.Infrastructure.DataAccess.Repositories;

//internal para que o projeto de API nao enxergue essa classe, ela seja vista apenas dentro de infrastructure
internal class DespesasRepository : IDespesasRepository
{
    private readonly PaoDuroDbContext _dbContext;
    public DespesasRepository(PaoDuroDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public void Add(Despesa despesa)
    {
        _dbContext.Despesas.Add(despesa);
    }
}
