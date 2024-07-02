using PaoDuro.Domain.Entities;

namespace PaoDuro.Domain.Repositories.Despesas;

public interface IDespesasUpdateOnlyRepository
{
    Task<Despesa?> GetById(long id);
    void Update(Despesa despesa);
}
