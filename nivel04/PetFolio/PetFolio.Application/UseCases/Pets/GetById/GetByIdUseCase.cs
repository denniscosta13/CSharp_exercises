using PetFolio.Communication.Responses;

namespace PetFolio.Application.UseCases.Pets.Get;

public class GetByIdUseCase
{
    public ResponsePetJson Execute(int id)
    {
        return new ResponsePetJson
        {
            Id = id,
            Name = "Hulk",
            Birthday = new DateTime(2015, 12, 25),
            Type = Communication.Enums.PetType.Dog
        };
    }
}
