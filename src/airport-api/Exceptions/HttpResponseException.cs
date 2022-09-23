namespace airport_api.Exceptions;
using System.Net;

public class HttpResponseException : Exception
{
    public HttpStatusCode StatusCode { get; }

    public HttpResponseException(HttpStatusCode httpStatusCode,string message) : base(message)
    {
        this.StatusCode = httpStatusCode;
    }
}