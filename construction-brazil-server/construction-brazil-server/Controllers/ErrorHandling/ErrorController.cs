using construction_brazil_server.Interfaces.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace construction_brazil_server.Controllers.Error
{
    [ApiController]
    [Route("/Error")]
    public class ErrorController : Controller
    {
        private readonly ILogService _logService;

        public ErrorController(ILogService logService)
            => _logService = logService;

        [Route("AppException")]
        public IActionResult AppException()
        {
            // Get the exception
            IExceptionHandlerFeature context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            Exception ex = context?.Error;

            // Log the exception (if you have the stack trace you don't need to separately log the
            // class and method that threw the exception, you can find that in the stack trace.
            if (ex != null)
                _logService.LogCritical(ex.Message, ex);

            // return a vague error message
            return Problem(
                detail: "A problem occurred while handling your request.",
                title: "Error");
        }

        [Route("LocalAppException")]
        public IActionResult LocalAppException()
        {
            // This isn't in production, no need to log it to the database.  Let's just return it
            // so that we can see the error and fix it.
            IExceptionHandlerFeature context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return Problem(
                detail: context.Error.StackTrace,
                title: context.Error.Message);
        }
    }

}
