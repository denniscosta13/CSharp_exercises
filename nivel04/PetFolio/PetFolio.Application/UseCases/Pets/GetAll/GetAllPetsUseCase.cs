using PetFolio.Communication.Responses;

namespace PetFolio.Application.UseCases.Pets.GetAll;

public class GetAllPetsUseCase
{
    public ResponseAllPetJson Execute()
    {
        return new ResponseAllPetJson
        {
            Pets =
            [
                new ResponseShortPetJson {
                    Id = 1,
                    Name = "Blake",
                    Type = Communication.Enums.PetType.Dog
                }
            ]
        };
    }
}
