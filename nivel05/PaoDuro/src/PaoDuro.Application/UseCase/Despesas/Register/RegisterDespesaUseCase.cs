using PaoDuro.Communication.Enums;
using PaoDuro.Communication.Requests;
using PaoDuro.Communication.Responses;
using PaoDuro.Exception.Exceptions;

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
        var validator = new RegisterDespesaValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
