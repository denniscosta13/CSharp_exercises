namespace PaoDuro.Application.UseCase.Despesas.Delete;

public interface IDeleteDespesaUseCase
{
    Task Execute(long id);
}
