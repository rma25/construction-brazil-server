using construction_brazil_server.Entities.Logs;
using Microsoft.EntityFrameworkCore;

namespace construction_brazil_server.DataStores
{
    public partial class ConstructionBrazil_Context : DbContext
    {
        private readonly string _connectionString;
        public ConstructionBrazil_Context(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ConstructionBrazil_Context(DbContextOptions<ConstructionBrazil_Context> options) : base(options)
        {
        }

        #region Application Log Tables
        public virtual DbSet<ExceptionLogging> ExceptionLoggings { get; set; }
        public virtual DbSet<ApplicationLogging> ApplicationLoggings { get; set; }
        public virtual DbSet<LoggingType> LoggingTypes { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _connectionString;

                if (string.IsNullOrEmpty(connectionString))
                {
                    var appSettingsEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environment.GetEnvironmentVariable("FULLSTORY_APP_ID");

                    if (!string.IsNullOrEmpty(appSettingsEnvironment))
                    {
                        IConfigurationRoot configuration = new ConfigurationBuilder()
                                                              .SetBasePath(Directory.GetCurrentDirectory())
                                                              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                                              .AddJsonFile($"appsettings{(!string.IsNullOrEmpty(appSettingsEnvironment) ? $".{appSettingsEnvironment}" : "")}.json", optional: false, reloadOnChange: true)
                                                              .Build();

                        connectionString = configuration.Get<AppConfig>()?.ConnectionStrings?.DefaultConnection ?? "";
                    }
                    else
                    {
                        IConfigurationRoot configuration = new ConfigurationBuilder()
                                                               .SetBasePath(Directory.GetCurrentDirectory())
                                                               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                                               .Build();

                        connectionString = configuration.GetConnectionString("DefaultConnection");
                    }
                }

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExceptionLogging>(entity =>
            {
                entity.Property(e => e.CreatedOn)
                      .IsRequired()
                      .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<ApplicationLogging>(entity =>
            {
                entity.Property(e => e.CreatedOn)
                      .IsRequired()
                      .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<LoggingType>(entity =>
            {
                entity.Property(e => e.CreatedOn)
                      .IsRequired()
                      .HasDefaultValueSql("(getutcdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
