using PaoDuro.Communication.Requests;
using PaoDuro.Communication.Responses;

namespace PaoDuro.Application.UseCase.Despesas.Update;

public interface IUpdateDespesaUseCase
{
    Task Execute(long id, RequestDespesaJson request);
}
