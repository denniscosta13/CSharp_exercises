using PetFolio.Communication.Requests;
using PetFolio.Communication.Responses;

namespace PetFolio.Application.UseCases.Pets.Register;

public class RegisterPetUseCase
{
    public ResponseRegisterPetJson Execute(RequestPetJson request)
    {
        return new ResponseRegisterPetJson
        {
            Id = 7,
            Name = request.Name
        };
    }
}

