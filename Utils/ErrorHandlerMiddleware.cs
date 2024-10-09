﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace CatalogMicroservice.Utils
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleException(context, e);
            }
        }
        public static Task HandleException(HttpContext context,
            Exception e)
        {
            var statusCode = StatusCodes.Status500InternalServerError;
            var result = JsonSerializer.Serialize(new
            {
                error = e.Message
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}
