using Desafio.Communication.Enums;

namespace Desafio.Communication.Requests;

public class RequestTaskJson
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskPriority Priority { get; set; }
    public DateTime Deadline { get; set; }
    public Enums.TaskStatus Status { get; set; }
}
