using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace AspNetNewsAgregatorMvcApp.Filters;

public class HappyExceptionFilter : Attribute, IExceptionFilter
{
    private readonly string _message;

    public HappyExceptionFilter(string message)
    {
        _message = message;
    }

    public void OnException(ExceptionContext context)
    {
        string? actionName = context.ActionDescriptor.DisplayName;
        string? exceptionMessage = context.Exception.Message;
        string? stackTrace = context.Exception.StackTrace;

        Log.Error(exceptionMessage);

        context.Result = new ContentResult()
        {
            Content = $"Keep calm. {_message} It is just an exception =)"
        };

        context.ExceptionHandled = true;
    }
}