using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(
            //RequestDelegate can process http request  and we called it next
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger,
            //check if we are in development mode
            IHostEnvironment env
         )
        {
            _logger = logger;
            _env = env;
            _next = next;

        }
        //bcz Execption handle middleware we need a try catch block
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                //if there's no execption then it will move to it's next stage
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                //we are gonna set the status code to be to be a 500 internal server error
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //check to see if we are in dev mode .env
                var response = _env.IsDevelopment()
                    // if we are in development
                    //we wanna pass a status code it will be an int 
                    ? new ApiException((int)HttpStatusCode.InternalServerError,
                    //takes parameters of Message
                    ex.Message,
                    // for details it gonna take StackTrace and we'll output it as a string
                    ex.StackTrace.ToString())
                    //else for in production
                    // 
                    : new ApiException((int)HttpStatusCode.InternalServerError);

                // because the messsage key is 
                // Server 
                // Message
                // we lose case server and message
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy =
                JsonNamingPolicy.CamelCase
                };
                // pass in option for lower camelcase
                // this will make everything consistent as well
                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }

        }
    }
}