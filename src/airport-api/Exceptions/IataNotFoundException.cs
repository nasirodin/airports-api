using System.Net;

namespace airport_api.Exceptions;

public class IataNotFoundException : HttpResponseException
{
    public IataNotFoundException() : 
        base(HttpStatusCode.NotFound, "Not Found")
    {
    }
}