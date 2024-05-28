using Desafio.Communication.Responses;

namespace Desafio.Application.UseCases.Tasks.GetById;

public class GetByIdUseCase
{
    public ResponseTaskJson Execute(int id)
    {
        return new ResponseTaskJson
        {
            Id = id,
            Title = "Teste By Id",
            Description = "Teste do get by id da API.",
            Deadline = new DateTime(2024, 05, 29),
            Priority = Communication.Enums.TaskPriority.High,
            Status = Communication.Enums.TaskStatus.InProgress
        };
    }
}
