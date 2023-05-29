using System.Runtime.CompilerServices;
using construction_brazil_server.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace construction_brazil_server.Controllers.Base
{
    public abstract class BaseController : ControllerBase
    {        
        protected ILogService LogService;        
       
        protected MyControllerBase(ILogService logService) => LogService = logService;        
        
        protected ActionResult HandleBadRequest(string badParameterName, object value, [CallerMemberName] string caller = "")
            => HandleError(BadRequest, $"{badParameterName} can't be {value ?? "Not Found"}", caller);

        protected ActionResult HandleBadRequest(string message, [CallerMemberName] string caller = "")
            => HandleError(BadRequest, message, caller);

        protected ActionResult HandleNotFound(string message, [CallerMemberName] string caller = "")
            => HandleError(NotFound, message, caller);

        protected ActionResult HandleNotFound(string badParameterName, object value, [CallerMemberName] string caller = "")
           => HandleError(BadRequest, $"{badParameterName} wasn't found for {badParameterName} = {value ?? "Not Found"}", caller);

        protected ActionResult HandleError(Func<object, ActionResult> result, string message, [CallerMemberName] string caller = "")
        {
            LogService.LogInformation(message, GetType().Name, caller); // <-- should be derived class name

            return result(message);
        }        
    }
}
