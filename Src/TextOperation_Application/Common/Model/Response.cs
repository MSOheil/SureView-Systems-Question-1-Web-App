

namespace TextOperation_Application.Common.Model;

public class Response<T>
{
    public Response(string message)
    {
        Message = message;
    }
    public string Message { get;private set; }
    public HttpStatusCode StatusCode { get; set; }
    public T Result { get; set; }
}
