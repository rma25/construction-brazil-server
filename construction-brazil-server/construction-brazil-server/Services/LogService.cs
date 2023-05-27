using System.Runtime.CompilerServices;
using construction_brazil_server.DataStores;
using construction_brazil_server.Entities.Logs;
using construction_brazil_server.Interfaces.Services;
using EEPServer.Constants;
using Microsoft.EntityFrameworkCore;

namespace construction_brazil_server.Services
{
    public class LogService : ILogService
    {
        private readonly ILogger<LogService> _logger;
        protected readonly AppConfig _appConfig;

        public LogService(ILogger<LogService> logger, AppConfig appConfig)
        {
            _logger = logger;
            _appConfig = appConfig;
        }

        protected bool DoesLogTypeExists(long logTypeId)
        {
            using var context = new ConstructionBrazil_Context(_appConfig.ConnectionStrings.DefaultConnection);

            return context.LoggingTypes.Any(x => x.LoggingTypeId == logTypeId);
        }


        /// <summary>
        /// Logs the exception to the database
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>New ExceptionLoggingId</returns>
        protected long Insert(Exception ex)
        {
            if (ex == null)
                throw new ArgumentNullException(nameof(ex));

            using var context = new ConstructionBrazil_Context(_appConfig.ConnectionStrings.DefaultConnection);

            var newException = new ExceptionLogging()
            {
                Message = ex.Message,
                InnerExceptionMessage = ex.InnerException?.Message ?? string.Empty,
                Source = ex.Source,
                StackTrace = ex.StackTrace,
                Type = ex.GetType().ToString()
            };

            context.ExceptionLoggings.Add(newException);
            context.Entry(newException).State = EntityState.Added;

            context.SaveChanges();

            context.ChangeTracker.Clear();

            return newException.ExceptionLoggingId;
        }

        public void LogCritical(string message, Exception ex, string controllerName = "", [CallerMemberName] string methodName = "")
        {
            long newExceptionId;

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            // Log on the server
            _logger.LogError(ex, message);

            using var context = new ConstructionBrazil_Context(_appConfig.ConnectionStrings.DefaultConnection);

            var logTypeId = context.LoggingTypes.FirstOrDefault(x => x.Nome.ToLower() == EntityConstants.ApplicationLoggingTypeConstants.Critical.ToLower())?.LoggingTypeId ?? 0;

            if (!DoesLogTypeExists(logTypeId))
                throw new ArgumentException($"{nameof(logTypeId)} = {logTypeId} can't be found.");

            newExceptionId = Insert(ex);

            var newLog = new ApplicationLogging()
            {
                Mensagem = message,
                LoggingTypeId = logTypeId,
                ExceptionLoggingId = newExceptionId
            };

            if (!string.IsNullOrEmpty(controllerName))
                newLog.ControllerName = controllerName;
            if (!string.IsNullOrEmpty(methodName))
                newLog.MethodName = methodName;

            context.ApplicationLoggings.Add(newLog);
            context.Entry(newLog).State = EntityState.Added;

            context.SaveChanges();

            context.ChangeTracker.Clear();
        }

        public void LogInformation(string message, string controllerName = "", [CallerMemberName] string methodName = "")
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            _logger.LogInformation(message);

            using var context = new ConstructionBrazil_Context(_appConfig.ConnectionStrings.DefaultConnection);

            var logTypeId = context.LoggingTypes.FirstOrDefault(x => x.Nome.ToLower() == EntityConstants.ApplicationLoggingTypeConstants.Information.ToLower())?.LoggingTypeId ?? 0;

            if (!DoesLogTypeExists(logTypeId))
                throw new ArgumentException($"{nameof(logTypeId)} = {logTypeId} can't be found.");

            var newLog = new ApplicationLogging()
            {
                Mensagem = message,
                LoggingTypeId = logTypeId
            };

            if (!string.IsNullOrEmpty(controllerName))
                newLog.ControllerName = controllerName;
            if (!string.IsNullOrEmpty(methodName))
                newLog.MethodName = methodName;

            context.ApplicationLoggings.Add(newLog);
            context.Entry(newLog).State = EntityState.Added;

            context.SaveChanges();

            context.ChangeTracker.Clear();
        }

    }
}
