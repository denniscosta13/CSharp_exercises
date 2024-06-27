using AutoMapper;
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
    private readonly IDespesasWriteOnlyRepository _respository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterDespesaUseCase(
        IDespesasWriteOnlyRepository repository, 
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _respository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseRegisterDespesaJson> Execute(RequestRegisterDespesaJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Despesa>(request);

        await _respository.Add(entity);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisterDespesaJson>(entity);
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
