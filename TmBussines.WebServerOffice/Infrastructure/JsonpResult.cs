using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace TmBussines.WebServerOffice.Infrastructure
{
    public class JsonpResult : JsonResult
    {
        public JsonpResult(object value) : base(value)
        {
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            HttpResponse response = context.HttpContext.Response;

            if (!String.IsNullOrEmpty(ContentType))
                response.ContentType = ContentType;
            else
                response.ContentType = "application/javascript";

            if (Value != null)
            {
                HttpRequest request = context.HttpContext.Request;
                string serializedJson = JsonSerializer.Serialize(Value);
                string result = $"{request.Query["callback"]}({serializedJson})";
                await response.WriteAsync(result);
            }
        }
    }

}
