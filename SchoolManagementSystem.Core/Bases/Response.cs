using System.Net;

namespace SchoolManagementSystem.Core.Bases
{
    public class Response<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Meta { get; set; }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        public Response() { }
        public Response(T data, string message = null)
        {
            Succeeded = true;
            Data = data;
            Message = message;
        }
        public Response(string message, bool succeeded)
        {
            Message = message;
            Succeeded = succeeded;
        }
    }
}
