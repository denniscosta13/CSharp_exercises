using PaoDuro.Domain.Entities;
using PaoDuro.Domain.Repositories.Despesas;

namespace PaoDuro.Infrastructure.DataAccess.Repositories;

//internal para que o projeto de API nao enxergue essa classe, ela seja vista apenas dentro de infrastructure
internal class DespesasRepository : IDespesasRepository
{
    public void Add(Despesa despesa)
    {
        var dbContext = new PaoDuroDbContext();

        dbContext.Despesas.Add(despesa);
        dbContext.SaveChanges();
    }
}
