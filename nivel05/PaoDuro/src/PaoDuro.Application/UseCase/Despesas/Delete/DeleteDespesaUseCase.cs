using PaoDuro.Domain.Repositories;
using PaoDuro.Domain.Repositories.Despesas;
using PaoDuro.Exception.Exceptions;
using PaoDuro.Exception;

namespace PaoDuro.Application.UseCase.Despesas.Delete;

public class DeleteDespesaUseCase : IDeleteDespesaUseCase
{
    private readonly IDespesasWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteDespesaUseCase(IDespesasWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (result == false)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        await _unitOfWork.Commit();
    }
}
