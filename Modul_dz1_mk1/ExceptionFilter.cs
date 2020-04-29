using Logic.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Modul_dz1_mk1
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is IncorrectRequestException)
            {
                context.ExceptionHandled = true;
                context.Result = new ContentResult()
                {
                    StatusCode = 400,
                    ContentType = "application/json",
                    Content = JsonConvert.SerializeObject(new
                    {
                        error = context.Exception.Message
                    })
                };
            }
        }
    }
}