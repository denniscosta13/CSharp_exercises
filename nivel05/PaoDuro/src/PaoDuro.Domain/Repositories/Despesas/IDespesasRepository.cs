using PaoDuro.Domain.Entities;

namespace PaoDuro.Domain.Repositories.Despesas;

public interface IDespesasRepository
{
    Task Add(Despesa despesa);

    Task<List<Despesa>> GetAll();
}
