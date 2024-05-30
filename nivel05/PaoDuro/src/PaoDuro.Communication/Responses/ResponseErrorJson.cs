namespace PaoDuro.Communication.Responses;

public class ResponseErrorJson
{
    public List<string> ErrorMessages { get; set; } = [];

    public ResponseErrorJson(string errorMessage)
    {
        ErrorMessages = [errorMessage];
    }

    public ResponseErrorJson(List<string> errorsList)
    {
        ErrorMessages = errorsList;
    }
}
