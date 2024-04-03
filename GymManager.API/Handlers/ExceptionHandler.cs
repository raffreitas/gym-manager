using GymManager.Core.Exceptions;

using Microsoft.AspNetCore.Diagnostics;

namespace GymManager.API.Handlers;

public class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        (int statusCode, string errorMessage) = exception switch
        {
            InvalidLoginException => (401, exception.Message),
            ResourceNotFoundException => (404, exception.Message),
            DomainException => (400, exception.Message),
            _ => (500, "Erro interno no servidor. Tente novamente")
        };


        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(new { Message = errorMessage }, cancellationToken);
        return true;
    }
}
