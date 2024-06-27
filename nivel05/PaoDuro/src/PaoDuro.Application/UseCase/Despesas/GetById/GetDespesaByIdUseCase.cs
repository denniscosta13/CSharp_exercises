using AutoMapper;
using PaoDuro.Communication.Responses;
using PaoDuro.Domain.Repositories.Despesas;
using PaoDuro.Exception;
using PaoDuro.Exception.Exceptions;

namespace PaoDuro.Application.UseCase.Despesas.GetById;

public class GetDespesaByIdUseCase : IGetDespesaByIdUseCase
{
    private readonly IDespesasReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetDespesaByIdUseCase(IDespesasReadOnlyRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<ResponseDespesaJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if (result is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        return _mapper.Map<ResponseDespesaJson>(result);
    }
}
