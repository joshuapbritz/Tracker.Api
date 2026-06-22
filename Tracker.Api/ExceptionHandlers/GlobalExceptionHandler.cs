using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Tracker.Api.ExceptionHandlers
{
    public sealed class ExceptionResult(int statusCode, string title, string message)
    {
        public int StatusCode { get; init; } = statusCode;
        public string Title { get; init; } = title;
        public string Message { get; init; } = message;

        /// <summary>
        /// Matches the exception to a specific ExceptionResult based on its type. This is done as a switch
        /// instead of a dictionary because a dictionary will not match derived types and so we would need
        /// to map each exception manually. This gives us a cleaner and more extensible approach
        /// </summary>
        public static ExceptionResult FromException(Exception exception)
        {
            return exception switch
            {
                ArgumentException ex => new ExceptionResult(
                    statusCode: StatusCodes.Status400BadRequest,
                    title: "Invalid argument",
                    message: ex.Message),
                _ => DefaultException()
            };
        }

        private static ExceptionResult DefaultException()
        {
            return new(
                statusCode: StatusCodes.Status500InternalServerError,
                title: "An unexpected error occurred",
                message: "Please try again later or contact support if the issue persists."
            );
        }
    }

    public sealed class GlobalExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
    {
        private readonly IProblemDetailsService _problemDetailsService = problemDetailsService;

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            ExceptionResult er = ExceptionResult.FromException(exception);

            ProblemDetails problemDetails = new()
            {
                Type = $"https://httpstatuses.com/{er.StatusCode}",
                Status = er.StatusCode,
                Title = er.Title,
                Detail = er.Message,
                Instance = httpContext.Request.Path
            };

            problemDetails.Extensions["traceId"] = httpContext.TraceIdentifier;
            httpContext.Response.StatusCode = er.StatusCode;

            return await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = problemDetails
            });
        }
    }
}
