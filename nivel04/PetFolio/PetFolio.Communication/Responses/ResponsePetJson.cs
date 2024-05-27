using PetFolio.Communication.Enums;

namespace PetFolio.Communication.Responses;

public class ResponsePetJson
{
    public int Id { get; set; }
    public string Name { get; set; }
    public PetType Type { get; set; }
    public DateTime Birthday { get; set; }
    
}
