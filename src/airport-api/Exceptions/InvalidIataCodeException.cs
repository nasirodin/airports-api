using System.Net;

namespace airport_api.Exceptions;

public sealed class InvalidIataCodeException : HttpResponseException
{
    public InvalidIataCodeException(string code)
        : base(HttpStatusCode.BadRequest, $"IATA Code {code} is not Valid")
    {

    }
}