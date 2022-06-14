using System.Net;

namespace DFAPI
{
    public class Response
    {
        public HttpStatusCode Code { get; set; }
        public string? Status { get; set; }
        public object? Data { get; set; }
        public string? Message { get; set; }
    }
}
