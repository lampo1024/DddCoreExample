namespace DddCoreExample.Api.Models
{
    public class Response<TReturn> : Response
    {
        public TReturn Object { get; set; }
    }
}
