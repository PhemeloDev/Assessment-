using AssesmentWebApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AssesmentWebApi.Filter
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        [System.Obsolete]
        private readonly IHostingEnvironment _env;

        [System.Obsolete]
        public JsonExceptionFilter(IHostingEnvironment env)
        {
            _env = env;
        }
        public void OnException(ExceptionContext context)
        {
            var error = new ApiError();
            if (_env.IsDevelopment())
            {
                error.Message = context.Exception.Message;
                error.Detail = context.Exception.StackTrace;
            }
            else
            {
                error.Message = "A server error occurred";
                error.Detail = context.Exception.Message;
            }


            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };
        }
    }
}
