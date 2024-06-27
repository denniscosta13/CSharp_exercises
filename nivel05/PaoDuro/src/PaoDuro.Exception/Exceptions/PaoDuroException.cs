namespace PaoDuro.Exception.Exceptions;

public abstract class PaoDuroException : SystemException
{
    protected PaoDuroException(string message) :base(message)
    {
        
    }
}
