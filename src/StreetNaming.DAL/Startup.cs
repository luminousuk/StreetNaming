using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using StreetNaming.DAL.PostgreSQL;

namespace StreetNaming.DAL
{
    public class Startup
    {
        // NOT INTENDED TO BE HOSTED - STARTUP CLASS TO ENABLE EF MIGRATIONS

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
                builder.AddUserSecrets();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                .AddNpgsql()
                .AddDbContext<StreetNamingContext>(options =>
                    options.UseNpgsql(Configuration["Data:DefaultConnection:ConnectionString"]));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }
    }
}