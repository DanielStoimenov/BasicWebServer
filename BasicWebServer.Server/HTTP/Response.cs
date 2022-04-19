using System;

namespace BasicWebServer.Server.HTTP
{
    public class Response
    {
        public StatusCode StatusCode { get; init; }

        public HeaderCollection Headers { get; } = new HeaderCollection();

        public string Body { get; set; }

        public Response(StatusCode statusCode)
        {
            StatusCode = statusCode;

            Headers.Add(Header.Server, "My Web Server");
            Headers.Add(Header.Date, $"{DateTime.UtcNow:r}");
        }
    }
}