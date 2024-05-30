using FluentValidation;
using PaoDuro.Communication.Requests;

namespace PaoDuro.Application.UseCase.Despesas.Register;

public class RegisterDespesaValidator : AbstractValidator<RequestRegisterDespesaJson>
{
    public RegisterDespesaValidator()
    {
        RuleFor(despesa => despesa.Title).NotEmpty().WithMessage("Título é obrigatório.");
        RuleFor(despesa => despesa.Amount).GreaterThan(0).WithMessage("Valor precisa ser maior que 0.");
        RuleFor(despesa => despesa.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Você não pode adicionar despesas futuras.");
        RuleFor(despesa => despesa.PaymentType).IsInEnum().WithMessage("Forma de pagamento inválida.");
        
    }
}
