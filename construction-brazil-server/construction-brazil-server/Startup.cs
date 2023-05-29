using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http.Features;
using System.IdentityModel.Tokens.Jwt;
using Serilog;
using construction_brazil_server.DataStores;
using Serilog.Events;
using construction_brazil_server.Extensions.DataStores;
using Newtonsoft.Json;
using construction_brazil_server.Extensions.DepedencyInjection;
using System.Reflection;
using construction_brazil_server.Interfaces.Shared;
using construction_brazil_server.Interfaces.Static;

namespace construction_brazil_server
{
    public partial class Startup
    {
        private readonly AppConfig _appConfig;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            _appConfig = configuration.Get<AppConfig>();

            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Verbose()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                        .MinimumLevel.Override("System", LogEventLevel.Warning)
                        .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                        .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .CreateLogger();

            Log.Logger.Information($"Environment name: {env.EnvironmentName}");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // This is to allow bigger files to be uploaded
            services.Configure<FormOptions>(options =>
            {
                options.MemoryBufferThreshold = int.MaxValue;
                options.MultipartBodyLengthLimit = long.MaxValue;
            });

            services.AddSingleton(Log.Logger);
            services.AddSingleton(_appConfig);
            services.AddSingleton(_appConfig.ConnectionStrings);
            services.AddSingleton(_appConfig.Elasticsearch);

            services.AddScoped<IDddRepository, DddRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<ILoggingTypeRepository, LoggingTypeRepository>();
            services.AddScoped<IProfissionalTypeRepository, ProfissionalTypeRepository>();
            services.AddScoped<ISexoRepository, SexoRepository>();

            // Injecting Contexts
            services.AddDbContext<ConstructionBrazil_Context>(options =>
            {
                // Setting a Connection Timeout because some files are too big and need a longer connection timeout (180 seconds)
                options.UseSqlServer(_appConfig.ConnectionStrings.DefaultConnection,
                    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                                                        .CommandTimeout(_appConfig.ConnectionStrings.ConnectionTimeout)
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
                        .SetPreflightMaxAge(TimeSpan.FromMinutes(_appConfig.CorsPolicy.TimeoutInMinutes)));
            });

            // Swagger
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Version = "v1",
            //        Title = "SINPROEGO",
            //        Description = "Demonstrating Restful Web Api Skills through a CRUD application"
            //    });
            //});

            services.AddLazyCache();
            services.AddControllers() // Make TimeSpan serialize correctly I.E. as a string
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ConstructionBrazil_Context dataContext)
        {
            // Display a custom page in case of an exception in the controller
            app.UseExceptionHandler(
                env.IsDevelopment()
                    ? "/Error/LocalAppException"
                    : "/Error/AppException");

            app.UseCors("CorsPolicy");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SINPROEGO");
            });

            Log.Logger.Information("Begining data seeding...");

            // If there is no data in certain tables, populate it with initial data
            dataContext.EnsureSeedDataForContext();

            Log.Logger.Information("Completed data seeding...");

            // Displaying the status code in the browser instead of a blank page;
            app.UseStatusCodePages();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Log.Logger.Information("Start up completed.");
        }

    }
}

