using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Core.Exceptions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception.GetType() == typeof(ValidationException)) return CreateValidationException(context, exception);
            if (exception.GetType() == typeof(NotFoundException)) return CreateNotFoundException(context, exception);
            if(exception.GetType() == typeof(BusinessException)) return CreateBusinessException(context, exception);
            return CreateInternalException(context, exception);
        }

        private Task CreateNotFoundException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;

            return context.Response.WriteAsync(new NotFoundProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = "https://nowadays.com/exceptions/not-found",
                Title = "Not Found exception",
                Detail = exception.Message,
                Instance = context.Request.Path
            }.ToString());
        }

        private Task CreateBusinessException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

            return context.Response.WriteAsync(new BusinessProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://nowadays.com/exceptions/business",
                Title = "Business exception",
                Detail = exception.Message,
                Instance = context.Request.Path
            }.ToString());
        }

        private Task CreateValidationException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
            object errors = ((ValidationException)exception).Errors;

            return context.Response.WriteAsync(new ValidationProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://nowadays.com/exceptions/validation",
                Title = "Validation error(s)",
                Detail = "",
                Instance = context.Request.Path,
                Errors = errors
            }.ToString());
        }

        private Task CreateInternalException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

            return context.Response.WriteAsync(new InternalProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://nowadays.com/exceptions/internal",
                Title = "Internal exception",
                Detail = exception.Message,
                Instance = context.Request.Path
            }.ToString());
        }
    }
}
