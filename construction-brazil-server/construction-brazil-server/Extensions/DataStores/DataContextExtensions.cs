using construction_brazil_server.Constants;
using construction_brazil_server.DataStores;
using construction_brazil_server.Entities.Static;
using Microsoft.EntityFrameworkCore;

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
            var loggingTypes = GetLoggingTypes();

            foreach (var loggingType in loggingTypes)
            {
                if (!context.LoggingTypes.Any(x => x.Nome.ToLower() == loggingType.Nome.ToLower()))
                {
                    context.LoggingTypes.Add(loggingType);
                    context.Entry(loggingType).State = EntityState.Added;
                    context.SaveChanges();
                    context.ChangeTracker.Clear();
                }
            }

            var ddds = GetDdds();

            foreach (var ddd in ddds)
            {
                if (!context.Ddds.Any(x => x.NumeroDeDdd == ddd.NumeroDeDdd))
                {
                    context.Ddds.Add(ddd);
                    context.Entry(ddd).State = EntityState.Added;
                    context.SaveChanges();
                    context.ChangeTracker.Clear();
                }
            }

            var sexos = GetSexos();

            foreach (var sexo in sexos)
            {
                if (!context.Sexos.Any(x => x.Tipo.ToLower() == sexo.Tipo.ToLower()))
                {
                    context.Sexos.Add(sexo);
                    context.Entry(sexo).State = EntityState.Added;
                    context.SaveChanges();
                    context.ChangeTracker.Clear();
                }
            }

            var estados = GetEstados();

            foreach (var estado in estados)
            {
                if (!context.Estados.Any(x => x.Nome.ToLower() == estado.Nome.ToLower()))
                {
                    context.Estados.Add(estado);
                    context.Entry(estado).State = EntityState.Added;
                    context.SaveChanges();
                    context.ChangeTracker.Clear();
                }
            }

            var profissionalTypes = GetProfissionalTypes();

            foreach (var profissionalType in profissionalTypes)
            {
                if (!context.ProfissionalTypes.Any(x => x.Tipo.ToLower() == profissionalType.Tipo.ToLower()))
                {
                    context.ProfissionalTypes.Add(profissionalType);
                    context.Entry(profissionalType).State = EntityState.Added;
                    context.SaveChanges();
                    context.ChangeTracker.Clear();
                }
            }
        }

        private static List<LoggingType> GetLoggingTypes()
        {
            var logTypes = typeof(EntityConstants.ApplicationLoggingTypeConstants)
                                  .GetFields()                                  
                                  .Select(logType => new LoggingType()
                                  {
                                      Nome = logType?.GetValue(null)?.ToString() ?? "",
                                      Descricao = "Isso serve para ajudar a identificar o tipo de log",
                                      Criado = DateTimeOffset.UtcNow
                                  })
                                  .ToList();

            return logTypes;
        }

        private static List<Ddd> GetDdds()
        {
            var ddds = EntityConstants.DddConstants.NumeroDeDdds.Select(numeroDeDdd => new Ddd()
            {
                NumeroDeDdd = numeroDeDdd,
                Criado = DateTimeOffset.UtcNow
            }).ToList();

            return ddds;
        }

        private static List<Sexo> GetSexos()
        {
            var sexos = EntityConstants.SexoConstants.Tipos.Select(tipo => new Sexo()
            {
                Tipo = tipo,
                Criado = DateTimeOffset.UtcNow
            }).ToList();

            return sexos;
        }

        private static List<Estado> GetEstados()
        {
            var estados = EntityConstants.EstadoConstants.Estados.Select(x => new Estado()
            {
                Uf = x.Uf,
                Nome = x.Nome,
                Criado = DateTimeOffset.UtcNow
            }).ToList();

            return estados;
        }

        private static List<ProfissionalType> GetProfissionalTypes()
        {
            var profissionalTypes = EntityConstants.ProfissionalTypeConstants.Tipos.Select(tipo => new ProfissionalType()
            {
                Tipo = tipo,
                Criado = DateTimeOffset.UtcNow
            }).ToList();

            return profissionalTypes;
        }
    }
}
