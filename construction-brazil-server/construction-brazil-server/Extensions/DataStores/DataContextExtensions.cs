using construction_brazil_server.DataStores;
using construction_brazil_server.Entities.Static;
using EEPServer.Constants;

namespace construction_brazil_server.Extensions.DataStores
{
    public static class DataContextExtensions
    {
        /// <summary>
        /// Make sure to populate empty tables with initial data
        /// </summary>
        /// <param name="context"></param>
        public static void EnsureSeedDataForContext(this ConstructionBrazil_Context context)
        {
            var loggingTypes = GetLoggingTypes().ToList();

            if (context.LoggingTypes.Any())
                loggingTypes = loggingTypes.Where(x => !context.LoggingTypes.Any(y => y.Nome.ToLower() == x.Nome.ToLower())).ToList();
            else // Only add if there aren't any
                context.LoggingTypes.AddRange(loggingTypes);

            context.SaveChanges();
        }

        private static List<LoggingType> GetLoggingTypes()
        {
            var logTypes = typeof(EntityConstants.ApplicationLoggingTypes)
                                  .GetFields()
                                  .Select(logType => new LoggingType()
                                  {
                                      Nome = logType.GetValue(null).ToString(),
                                      Descricao = "Isso serve para ajudar a identificar o tipo de log",
                                      Criado = DateTimeOffset.UtcNow
                                  })
                                  .ToList();

            return logTypes;
        }
    }
}
