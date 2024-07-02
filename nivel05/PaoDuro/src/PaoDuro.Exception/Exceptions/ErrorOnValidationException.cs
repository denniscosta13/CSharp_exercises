using System.Net;

namespace PaoDuro.Exception.Exceptions;

public class ErrorOnValidationException : PaoDuroException
{
    private readonly List<string> _errors;

    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public ErrorOnValidationException(List<string> errors) :base(string.Empty)
    {

        this._errors = errors;

    }

    public override List<string> GetErrors()
    {
        return _errors;
    }
}
