using AutoMapper;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StreetNaming.Web.AutoMapper;
using StreetNaming.Web.Models;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace StreetNaming.Web
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _config;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

            var builder = new ConfigurationBuilder()
                .AddJsonFile("settings.json")
                .AddJsonFile($"settings.{_hostingEnvironment.EnvironmentName}.json", optional: true);

            builder.AddUserSecrets();

            builder.AddEnvironmentVariables();
            
            _config = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFramework()
                .AddNpgsql()
                .AddDbContext<StreetNamingEntities>(opts => opts.UseNpgsql(_config["Data:DefaultConnection:ConnectionString"]));

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new StreetNamingProfile());
            });
            services.AddSingleton(sp => mapperConfig.CreateMapper());
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_hostingEnvironment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseIISPlatformHandler();

            app.UseMvcWithDefaultRoute();

            app.UseStaticFiles();

            app.UseStatusCodePages();
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}