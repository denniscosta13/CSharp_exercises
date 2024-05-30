namespace PaoDuro.Exception.Exceptions;

public class ErrorOnValidationException : PaoDuroException
{
    public List<string> Errors { get; set; }

    public ErrorOnValidationException(List<string> errors)
    {

        this.Errors = errors;

    }
}
