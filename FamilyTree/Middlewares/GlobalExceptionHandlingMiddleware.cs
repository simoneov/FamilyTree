using FamilyTree.Exceptions;
using FamilyTree.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace FamilyTree.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger _logger;
        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (InvalidWeddingException e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Type = "Bad Request",
                    Title = "Bad Request",
                    Detail = "Invalid Data"
                };

                string json = JsonConvert.SerializeObject(problem);
                await context.Response.WriteAsync(json);
                context.Response.ContentType = "application/json";
            }
            catch (SecondWeddingWithoutDivorceWithSameWifeException e) 
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Type = "Bad Request",
                    Title = "Bad Request",
                    Detail = "You can't make a marriage between already married individuals"
                };

                string json = JsonConvert.SerializeObject(problem);
                await context.Response.WriteAsync(json);
                context.Response.ContentType = "application/json";
            }
        }
    }
}
