using AutoMapper;
using Gaurav.Danani.WooliesX.Application;
using Gaurav.Danani.WooliesX.Application.ApplicationSettings;
using Gaurav.Danani.WooliesX.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Gaurav.Danani.WooliesX.ServiceHost
{
    //TODO: Add GlobalExceptionFilter
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.Configure<AppSettings>(Configuration);
            services
                .AddServiceHost()
                .AddApplication()
                .AddInfrastructure();
            services.AddSingleton(CreateMapper());
        }
        
        private static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(mc =>
            {
                mc.AddInfrastructureMappingProfiles();
                mc.AddApplicationMappingProfiles();
            });

            return config.CreateMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}