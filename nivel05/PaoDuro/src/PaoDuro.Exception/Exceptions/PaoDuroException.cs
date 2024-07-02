namespace PaoDuro.Exception.Exceptions;

public abstract class PaoDuroException : SystemException
{
    protected PaoDuroException(string message) :base(message)
    {
        
    }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
