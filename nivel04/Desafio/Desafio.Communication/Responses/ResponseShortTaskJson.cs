namespace Desafio.Communication.Responses;

public class ResponseShortTaskJson
{
    public int Id { get; set; }
    public string Title { get; set; } =string.Empty;
    public Communication.Enums.TaskPriority Priority { get; set; }
}
