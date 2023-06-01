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
        private readonly ConstructionBrazil_Context _context;
        protected readonly AppConfig _appConfig;

        public LogService(ILogger<LogService> logger, AppConfig appConfig, ConstructionBrazil_Context context)
        {
            _logger = logger;
            _appConfig = appConfig;
            _context = context;
        }

        protected bool DoesLogTypeExists(long logTypeId)
        {
            return _context.LoggingTypes.Any(x => x.LoggingTypeId == logTypeId);
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

            var newException = new ExceptionLogging()
            {
                Message = ex.Message,
                InnerExceptionMessage = ex.InnerException?.Message ?? string.Empty,
                Source = ex.Source,
                StackTrace = ex.StackTrace,
                Type = ex.GetType().ToString()
            };

            _context.ExceptionLoggings.Add(newException);
            _context.Entry(newException).State = EntityState.Added;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            return newException.ExceptionLoggingId;
        }

        public void LogCritical(string message, Exception ex, string controllerName = "", [CallerMemberName] string methodName = "")
        {
            long newExceptionId;

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            // Log on the server
            _logger.LogError(ex, message);

            var logTypeId = _context.LoggingTypes.FirstOrDefault(x => x.Nome.ToLower() == EntityConstants.ApplicationLoggingTypeConstants.Critical.ToLower())?.LoggingTypeId ?? 0;

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

            _context.ApplicationLoggings.Add(newLog);
            _context.Entry(newLog).State = EntityState.Added;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();
        }

        public void LogInformation(string message, string controllerName = "", [CallerMemberName] string methodName = "")
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            _logger.LogInformation(message);

            var logTypeId = _context.LoggingTypes.FirstOrDefault(x => x.Nome.ToLower() == EntityConstants.ApplicationLoggingTypeConstants.Information.ToLower())?.LoggingTypeId ?? 0;

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

            _context.ApplicationLoggings.Add(newLog);
            _context.Entry(newLog).State = EntityState.Added;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();
        }

    }
}
