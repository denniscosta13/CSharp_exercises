namespace Desafio.Communication.Responses;

public class ResponseRegisterTaskJson
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Communication.Enums.TaskPriority Priority { get; set; }
}
