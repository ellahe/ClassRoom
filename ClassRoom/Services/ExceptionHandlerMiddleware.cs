using System;
using System.IO;
using System.Net;
using System.Text.Json;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ClassRoom.Services
{
    public static class ExceptionHandlerMiddleware 
        {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails(contextFeature.Error.Message)
                        {
                            StatusCode = context.Response.StatusCode,
                            DetailMessage = "detail Message of error"
                        }.ToString());
                    }
                });
            });
        }
    }

    public class ErrorDetails  : Exception
    {
        public ErrorDetails(string message):base(message)
        { }

        public int StatusCode { get; set; }
        public string DetailMessage { get; set; }

        public override string ToString()
        {
            return DetailMessage;
        }
    }
}
