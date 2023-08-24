using GestionLogistica.Abstraction.DTO;
using Newtonsoft.Json;
using System.Net;

namespace GestionLogistica.Global.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this._next = next;
            this._logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
        }

        public async Task InvokeAsync(HttpContext httpcontext)
        {
            try
            {
                await _next(httpcontext);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Ocurrio un error en la ejecucion: {Newtonsoft.Json.JsonConvert.SerializeObject(ex)}");
                await HandleGlobalExceptionAsync(httpcontext, ex);
            }
        }

        private static Task HandleGlobalExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
            ResponseServicesDTO resp = new ResponseServicesDTO();
            resp.ErrorDetails.ErrorStatusCode = StatusCodes.Status500InternalServerError;
            resp.ErrorDetails.ErroMessage = "Ocurrio un error en la ejecucion";
            resp.ErrorDetails.ErrorStackTrace = ex.StackTrace;
            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(resp));
        }


    }
}
