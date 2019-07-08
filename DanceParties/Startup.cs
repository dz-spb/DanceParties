using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using React.AspNet;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.Extensions.Logging;
using DanceParties.Interfaces.Repositories;
using DanceParties.Interfaces.Services;
using DanceParties.BusinessLogic;
using Models = DanceParties.Interfaces.BusinessModels;
using Entities = DanceParties.DataEntities;
using DanceParties.Repositories;

namespace DanceParties
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();
            services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName)
                .AddChakraCore();     

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            string connection = Configuration.GetConnectionString("MainDatabase");
            services.AddDbContext<Entities.DancePartiesContext>(options => options.UseSqlServer(connection));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();

            services.AddLogging();

            services.AddScoped<IRepository<Entities.Dance>, DanceRepository>();
            services.AddScoped<IRepository<Entities.City>, CityRepository>();
            services.AddScoped<IRepository<Entities.Location>, LocationRepository>();
            services.AddScoped<IRepository<Entities.Party>, PartyRepository>();
            services.AddScoped<IService<Models.Dance>, DanceService>();
            services.AddScoped<IService<Models.City>, CityService>();
            services.AddScoped<IService<Models.Location>, LocationService>();
            services.AddScoped<IService<Models.Party>, PartyService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseReact(config => { });
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.ConfigureCustomExceptionMiddleware();
            app.UseMvc();
        }
    }
}
