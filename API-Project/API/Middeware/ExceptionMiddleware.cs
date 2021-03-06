using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using Utility.Models;

namespace API.Middeware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next,IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsynce(context,ex,_env);
            }
            
            //after this line
        }

        private async Task HandleExceptionAsynce(HttpContext context, Exception exception, IWebHostEnvironment env)
        {
            var code = HttpStatusCode.InternalServerError;
            var errors = new APiErrorResponse() 
            { 
                StatusCode = (int)code
            };
            if (_env.IsDevelopment())
            {
                errors.Details = exception.StackTrace;
            }
            else
            {
                errors.Message = exception.Message;
            }
            switch (exception)
            {
                case ApplicationException e:
                    errors.Message = e.Message;
                    errors.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                    break;
                    default:
                    errors.Message = "Somnething is wrong in our systam";
                    break;
            }
            var result = JsonConvert.SerializeObject(errors);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = errors.StatusCode;
            await context.Response.WriteAsync(result);
        }
    }
}
