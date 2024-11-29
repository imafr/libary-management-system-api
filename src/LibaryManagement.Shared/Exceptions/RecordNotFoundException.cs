using System.Net;

namespace LibaryManagement.Shared.Exceptions;

public class RecordNotFoundException(string message) :
        BaseException(message, HttpStatusCode.NotFound);
