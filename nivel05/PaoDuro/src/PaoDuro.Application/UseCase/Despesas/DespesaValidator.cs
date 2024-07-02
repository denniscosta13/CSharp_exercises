using FluentValidation;
using PaoDuro.Communication.Requests;
using PaoDuro.Exception;

namespace PaoDuro.Application.UseCase.Despesas;

public class DespesaValidator : AbstractValidator<RequestDespesaJson>
{
    public DespesaValidator()
    {
        RuleFor(despesa => despesa.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITILE_REQUIRED);
        RuleFor(despesa => despesa.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
        RuleFor(despesa => despesa.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.FUTURE_EXPENSES);
        RuleFor(despesa => despesa.PaymentType).IsInEnum().WithMessage(ResourceErrorMessages.INVALID_PAYMENT_TYPE);

    }
}
