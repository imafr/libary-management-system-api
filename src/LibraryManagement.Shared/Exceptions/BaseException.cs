using System.Net;

namespace LibraryManagement.Shared.Exceptions;

public class BaseException : Exception
{
    public BaseException(
        string message,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message)
    {
        StatusCode = statusCode;
    }

    public HttpStatusCode StatusCode { get; protected set; }
}