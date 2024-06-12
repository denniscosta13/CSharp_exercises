using PaoDuro.Communication.Enums;
using PaoDuro.Communication.Requests;
using PaoDuro.Communication.Responses;
using PaoDuro.Domain.Entities;
using PaoDuro.Domain.Repositories;
using PaoDuro.Domain.Repositories.Despesas;
using PaoDuro.Exception.Exceptions;

namespace PaoDuro.Application.UseCase.Despesas.Register;

public class RegisterDespesaUseCase : IRegisterDespesaUseCase
{
    private readonly IDespesasRepository _respository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterDespesaUseCase(IDespesasRepository repository, IUnitOfWork unitOfWork)
    {
        _respository = repository;
        _unitOfWork = unitOfWork;
    }

    public ResponseRegisterDespesaJson Execute(RequestRegisterDespesaJson request)
    {
        Validate(request);

        var entity = new Despesa
        {
            Amount = request.Amount,
            Date = request.Date,
            Description = request.Description,
            Title = request.Title,
            PaymentType = (Domain.Enums.PaymentType)request.PaymentType
        };

        _respository.Add(entity);
        _unitOfWork.Commit();
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
