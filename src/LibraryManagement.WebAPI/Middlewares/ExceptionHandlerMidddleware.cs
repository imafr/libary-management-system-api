using LibraryManagement.Shared.Exceptions;
using LibraryManagement.Shared.Models;
using System.Net;

namespace LibraryManagement.WebAPI.Middlewares;

public class ExceptionHandlerMidddleware(ILogger<ExceptionHandlerMidddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exception occurred");
            await HandleException(ex, context);
        }
    }

    private async Task HandleException(Exception exception, HttpContext httpContext)
    {
        ErrorDescriptionModel errorDescriptionModel = GetErrorDescriptionModel(exception);

        httpContext.Response.StatusCode = errorDescriptionModel.StatusCode;
        await httpContext.Response.WriteAsJsonAsync(errorDescriptionModel);
    }

    private ErrorDescriptionModel GetErrorDescriptionModel(Exception exception)
    {
        return exception switch
        {
            BaseException baseException => HandleBaseException(baseException),
            _ => HandleGenericException(exception)
        };
    }

    private ErrorDescriptionModel HandleBaseException(BaseException baseException)
    {
        return CreateErrorDescriptionModel(
                baseException.StatusCode,
                baseException.Message,
                baseException.ToString());
    }

    private ErrorDescriptionModel HandleGenericException(Exception exception)
    {
        return CreateErrorDescriptionModel(
                HttpStatusCode.InternalServerError,
                exception.Message,
                exception.ToString());
    }

    private ErrorDescriptionModel CreateErrorDescriptionModel(
        HttpStatusCode statusCode,
        string message,
        string details)
    {
        return new ErrorDescriptionModel()
        {
            StatusCode = (int)statusCode,
            ErrorMessage = message,
            Details = details
        };
    }
}
