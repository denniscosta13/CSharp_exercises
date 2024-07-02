using System.Net;

namespace PaoDuro.Exception.Exceptions;

public  class NotFoundException : PaoDuroException
{
    public NotFoundException(string message) :base(message)
    {
        
    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        // forma antiga - Message faz parte da classe excpetion >> base(message) envia a string até ela e depois recuperamos ela abaixo:
        // return new List<string>() { Message };

        return [Message];
    }
}
