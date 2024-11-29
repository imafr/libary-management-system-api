using System.Net;

namespace LibraryManagement.Shared.Exceptions;

public class RecordNotFoundException(string message) :
        BaseException(message, HttpStatusCode.NotFound);
