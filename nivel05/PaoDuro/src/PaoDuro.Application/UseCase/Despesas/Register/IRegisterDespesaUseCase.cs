using PaoDuro.Communication.Requests;
using PaoDuro.Communication.Responses;

namespace PaoDuro.Application.UseCase.Despesas.Register;

public interface IRegisterDespesaUseCase
{
    ResponseRegisterDespesaJson Execute(RequestRegisterDespesaJson request);
}
