using System.Runtime.CompilerServices;

namespace construction_brazil_server.Interfaces.Services
{
    public interface ILogService
    {
        public void LogCritical(string message, Exception ex, string controllerName = "", [CallerMemberName] string methodName = "");

        public void LogInformation(string message, string controllerName = "", [CallerMemberName] string methodName = "");        
    }
}
