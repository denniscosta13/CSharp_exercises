using PaoDuro.Communication.Responses;

namespace PaoDuro.Application.UseCase.Despesas.GetById;

public interface IGetDespesaByIdUseCase
{
    Task<ResponseDespesaJson> Execute(long id);
}
