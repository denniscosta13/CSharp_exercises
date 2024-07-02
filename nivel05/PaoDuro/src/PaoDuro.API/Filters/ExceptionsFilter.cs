using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PaoDuro.Communication.Responses;
using PaoDuro.Exception;
using PaoDuro.Exception.Exceptions;

namespace PaoDuro.API.Filters;

public class ExceptionsFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is PaoDuroException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var paoDuroException = context.Exception as PaoDuroException;
        var errorResponse = new ResponseErrorJson(paoDuroException!.GetErrors());

        context.HttpContext.Response.StatusCode = paoDuroException.StatusCode;
        context.Result = new ObjectResult(errorResponse);


    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);

    }
}
