using AutoMapper;
using PaoDuro.Communication.Requests;
using PaoDuro.Domain.Repositories;
using PaoDuro.Domain.Repositories.Despesas;
using PaoDuro.Exception;
using PaoDuro.Exception.Exceptions;

namespace PaoDuro.Application.UseCase.Despesas.Update;

public class UpdateDespesaUseCase : IUpdateDespesaUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDespesasUpdateOnlyRepository _repository;
    public UpdateDespesaUseCase(IMapper mapper, IUnitOfWork unitOfWork, IDespesasUpdateOnlyRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;

    }
    public async Task Execute(long id, RequestDespesaJson request)
    {
        Validate(request);

        var despesa = await _repository.GetById(id);

        if (despesa == null) 
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);

        }
        _mapper.Map(request, despesa);

        _repository.Update(despesa);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestDespesaJson request)
    {
        var validator = new DespesaValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }

}
