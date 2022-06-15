using System.Collections;
using System.Net;

namespace DFAPI
{
    public static class Common
    {
        public static void CreateResponse<T>(HttpStatusCode code, string status, string message, out Response actionResponse, T objResponse) where T : IList
        {
            actionResponse = new Response()
            {
                Code = code,
                Status = status,
                Message = message,
                Data = objResponse
            };

        }
        public static void CreateResponse(HttpStatusCode code, string status, string message, out Response actionResponse)
        {
            actionResponse = new Response()
            {
                Code = code,
                Status = status,
                Message = message,
                Data = null
            };

        }
        public static void CreateErrorResponse<T>(HttpStatusCode code, out Response actionResponse, T objResponse) where T : Exception
        {
            var ex = (Exception)objResponse;
            actionResponse = new Response()
            {
                Code = code,
                Status = "Error occured while processing your request",
                Message = ex.Message,
                Data = null
            };

        }
    }
}
