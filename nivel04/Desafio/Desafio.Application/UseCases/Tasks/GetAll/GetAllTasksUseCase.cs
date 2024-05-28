using Desafio.Communication.Responses;

namespace Desafio.Application.UseCases.Tasks.GetAll;

public class GetAllTasksUseCase
{
    public ResponseAllTasksJson Execute()
    {
        return new ResponseAllTasksJson
        {
            Tasks = [
                new ResponseShortTaskJson {
                    Id = 1,
                    Title = "Test",
                    Priority = Communication.Enums.TaskPriority.Low
                },
                new ResponseShortTaskJson {
                    Id = 2,
                    Title = "Test2",
                    Priority = Communication.Enums.TaskPriority.High
                }
                ]
        };
    }
}
