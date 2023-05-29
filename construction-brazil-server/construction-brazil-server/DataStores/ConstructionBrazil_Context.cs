using construction_brazil_server.Entities.Logs;
using construction_brazil_server.Entities.Static;
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
        #endregion

        #region Static
        public virtual DbSet<LoggingType> LoggingTypes { get; set; }
        public virtual DbSet<Ddd> Ddds { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<ProfissionalType> ProfissionalTypes { get; set; }
        public virtual DbSet<Sexo> Sexos { get; set; }
        #endregion

        #region Regular Tables
        public virtual DbSet<Contato> Contatos { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Profissional> Profissionals { get; set; }
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
                entity.Property(e => e.Criado)
                      .IsRequired()
                      .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<ApplicationLogging>(entity =>
            {
                entity.Property(e => e.Criado)
                      .IsRequired()
                      .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<LoggingType>(entity =>
            {
                entity.Property(e => e.Criado)
                      .IsRequired()
                      .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Ddd>(entity =>
            {
                entity.Property(e => e.Criado)
                      .IsRequired()
                      .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Criado)
                      .IsRequired()
                      .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<ProfissionalType>(entity =>
            {
                entity.Property(e => e.Criado)
                      .IsRequired()
                      .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.Property(e => e.Criado)
                      .IsRequired()
                      .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Contato>(entity =>
            {
                entity.Property(e => e.Criado)
                      .IsRequired()
                      .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.Property(e => e.Criado)
                      .IsRequired()
                      .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Profissional>(entity =>
            {
                entity.Property(e => e.Criado)
                      .IsRequired()
                      .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ProfissionalKey)
                      .IsRequired()
                      .HasDefaultValueSql("(NEWID())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
