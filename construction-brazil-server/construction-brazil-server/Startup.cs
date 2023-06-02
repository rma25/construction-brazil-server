using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Features;
using System.IdentityModel.Tokens.Jwt;
using Serilog;
using construction_brazil_server.DataStores;
using construction_brazil_server.Extensions.DataStores;
using Newtonsoft.Json;
using construction_brazil_server.Interfaces.Static;
using construction_brazil_server.Interfaces.Services;
using construction_brazil_server.Services;
using construction_brazil_server.Interfaces;

namespace construction_brazil_server
{
    public partial class Startup
    {
        private readonly AppConfig _appConfig = new AppConfig();

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _appConfig = configuration.Get<AppConfig>() ?? new AppConfig();

            Log.Logger.Information($"Environment name: {env.EnvironmentName}");

            if (_appConfig == null)
                Log.Logger.Fatal($"App Config is null.");

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Log.Logger.Information($"Started ConfigureServices...");

            // This is to allow bigger files to be uploaded
            services.Configure<FormOptions>(options =>
            {
                options.MemoryBufferThreshold = int.MaxValue;
                options.MultipartBodyLengthLimit = long.MaxValue;
            });

            services.AddSingleton(Log.Logger);
            services.AddSingleton(_appConfig);
            services.AddSingleton(_appConfig.ConnectionStrings);
            services.AddSingleton(_appConfig.ElasticConfig);
            services.AddSingleton(_appConfig.CorsPolicy);
            services.AddSingleton(_appConfig.StorageAccount);

            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IRemoteDataService, RemoteDataService>();
            services.AddScoped<IDddRepository, DddRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<ILoggingTypeRepository, LoggingTypeRepository>();
            services.AddScoped<IProfissionalTypeRepository, ProfissionalTypeRepository>();
            services.AddScoped<ISexoRepository, SexoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IProfissionalRepository, ProfissionalRepository>();

            if (_appConfig == null)
            {
                Log.Logger.Fatal($"App Config is null.");
                return;
            }

            if (string.IsNullOrEmpty(_appConfig?.ConnectionStrings?.DefaultConnection ?? ""))
                Log.Logger.Fatal($"App Config Connection string Default Connection not found.");
            else
                Log.Logger.Information($"Default Connection: {_appConfig?.ConnectionStrings?.DefaultConnection ?? ""}");

            // Injecting Contexts            
            services.AddDbContext<ConstructionBrazil_Context>(options =>
            {
                // Setting a Connection Timeout because some files are too big and need a longer connection timeout (180 seconds)
                options.UseSqlServer(_appConfig?.ConnectionStrings?.DefaultConnection ?? "",
                    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                                                        .CommandTimeout(_appConfig?.ConnectionStrings?.ConnectionTimeout ?? 60)
                                                        .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                                                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            // CORS
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .SetPreflightMaxAge(TimeSpan.FromMinutes(_appConfig?.CorsPolicy?.TimeoutInMinutes ?? 15)));
            });

            // Swagger
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Version = "v1",
            //        Title = "Construction Brazil",
            //        Description = "Demonstrating Restful Web Api Skills through a CRUD application"
            //    });
            //});

            services.AddLazyCache();
            services.AddControllers() // Make TimeSpan serialize correctly I.E. as a string
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddSignalR();

            Log.Logger.Information($"Completed ConfigureServices...");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ConstructionBrazil_Context dataContext)
        {
            Log.Logger.Information($"Started Configure...");

            // Display a custom page in case of an exception in the controller
            app.UseExceptionHandler(
                env.IsDevelopment()
                    ? "/Error/LocalAppException"
                    : "/Error/AppException");

            app.UseCors("CorsPolicy");

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Construction Brazil");
            //});

            Log.Logger.Information("Begining data seeding...");

            // If there is no data in certain tables, populate it with initial data
            dataContext.EnsureSeedDataForContext();

            Log.Logger.Information("Completed data seeding.");

            // Displaying the status code in the browser instead of a blank page;
            app.UseStatusCodePages();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Log.Logger.Information($"Completed Configure.");
            Log.Logger.Information("Start up completed.");
        }

    }
}

