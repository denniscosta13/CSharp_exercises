using PaoDuro.Domain.Entities;

namespace PaoDuro.Domain.Repositories.Despesas;

public interface IDespesasWriteOnlyRepository
{
    Task Add(Despesa despesa);

}
