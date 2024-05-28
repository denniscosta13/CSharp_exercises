using Desafio.Communication.Requests;
using Desafio.Communication.Responses;

namespace Desafio.Application.UseCases.Tasks.Register;

public class RegisterTaskUseCase
{
    public ResponseRegisterTaskJson Execute(RequestTaskJson request)
    {
        return new ResponseRegisterTaskJson
        {
            Id = 1,
            Title = request.Title,
            Priority = request.Priority,
        };
    }
}
