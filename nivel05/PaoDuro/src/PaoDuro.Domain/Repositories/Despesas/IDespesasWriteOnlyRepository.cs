using PaoDuro.Domain.Entities;

namespace PaoDuro.Domain.Repositories.Despesas;

public interface IDespesasWriteOnlyRepository
{
    Task Add(Despesa despesa);
    /// <summary>
    /// This function returns TRUE if the deletion was successful.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(long id);
}
