using PaoDuro.Domain.Entities;

namespace PaoDuro.Domain.Repositories.Despesas;

public interface IDespesasReadOnlyRepository
{
    Task<List<Despesa>> GetAll();
    Task<Despesa?> GetById(long id);
    Task<List<Despesa>> FilterByMonth(DateOnly date);
}
