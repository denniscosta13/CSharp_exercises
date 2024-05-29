using PaoDuro.Communication.Enums;
using PaoDuro.Communication.Requests;
using PaoDuro.Communication.Responses;

namespace PaoDuro.Application.UseCase.Despesas.Register;

public class RegisterDespesaUseCase
{
    public ResponseRegisterDespesaJson Execute(RequestRegisterDespesaJson request)
    {
        Validate(request);

        return new ResponseRegisterDespesaJson();
    }

    private void Validate(RequestRegisterDespesaJson request)
    {
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        if(titleIsEmpty)
        {
            throw new ArgumentException("Título é obrigatório.");
        }

        if(request.Amount <= 0)
        {
            throw new ArgumentException("Valor precisa ser maior que 0.");
        }

        var futureDate = DateTime.Compare(request.Date, DateTime.UtcNow);
        if(futureDate > 0)
        {
            throw new ArgumentException("Você não pode adicionar despesas futuras.");
        }

        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);

        if(!paymentTypeIsValid) 
        {
            throw new ArgumentException("Forma de pagamento inválida.");
        }

    }
}
