using Microsoft.EntityFrameworkCore;
using CamerOperationClassLibrary.Services;
using CamerOperationClassLibrary.Models;
using CamerOperationClassLibrary.AutoMapping.DtoModels;
using CamerOperationClassLibrary.EntityFramework.Repositories;
using CamerOperationClassLibrary.EntityFramework;


namespace CamerOperationClassLibrary
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile(".json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions();
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<AutoMappingProfile>();
            });

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            //context
            services.AddDbContext<CameraOperationContext>(
                options => options.UseSqlServer(connectionString),
                contextLifetime: ServiceLifetime.Scoped,
                optionsLifetime: ServiceLifetime.Transient);

            services.AddTransient<ICameraOperationContextFactory, CameraOperationContextFactory>();
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Fixation>, FixationRepository>();
            services.AddTransient<IRuleOfSearchRepository<RuleOfSearchByNumber>, RuleOfSearchByNumberRepository>();
            services.AddTransient<IRuleOfSearchRepository<RuleOfSearchBySpeed>, RuleOfSearchBySpeedRepository>();
            services.AddTransient<IRepository<TriggeringByNumber>, TriggeringByNumberRepository>();
            services.AddTransient<IRepository<TriggeringBySpeed>, TriggeringBySpeedRepository>();

            services.AddHostedService<TestRepos>();
            services.AddTransient<IViolationDetector, ViolationByNumberDetector>();
            services.AddTransient<IViolationDetector, ViolationBySpeedDetector>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostApplicationLifetime lifetime)
        {
            app.UseRouting();
            app.UseEndpoints(conf => conf.MapControllers());

            app.UseSwagger();
            app.UseSwaggerUI();
        }


    }

}
