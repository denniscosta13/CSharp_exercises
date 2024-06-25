using PaoDuro.Communication.Responses;

namespace PaoDuro.Application.UseCase.Despesas.GetAll;

public interface IGetAllDespesasUseCase
{
    Task<ResponseDespesaJson> Execute();
}
