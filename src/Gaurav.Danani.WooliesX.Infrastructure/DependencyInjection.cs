using System;
using AutoMapper;
using Gaurav.Danani.WooliesX.Application.Common.Interfaces;
using Gaurav.Danani.WooliesX.Infrastructure.MappingProfiles;
using Gaurav.Danani.WooliesX.Infrastructure.Proxies.WooliesXDevApi;
using Gaurav.Danani.WooliesX.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Gaurav.Danani.WooliesX.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITrolleyService, TrolleyService>();
            
            services.AddNamedHttpClients();
            return services;
        }

        private static IServiceCollection AddNamedHttpClients(this IServiceCollection services)
        {
            Application.ApplicationSettings.Proxies proxies;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                proxies = serviceProvider.GetRequiredService<IAppSettingsProvider>().AppSettings.Proxies;
            }

            services
                .AddRefitHttpClient<IWooliesXDevApiProxy>(proxies.WooliesXDevApi.BaseUrl,
                    proxies.WooliesXDevApi.DefaultTimeoutSec);
            
            return services;
        }

        private static void AddRefitHttpClient<TClient>(
            this IServiceCollection services,
            string baseUrl,
            int timeout
        ) where TClient : class
        {
            services
                .AddRefitClient<TClient>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(baseUrl);
                    c.Timeout = TimeSpan.FromSeconds(timeout);
                });
        }

        public static void AddInfrastructureMappingProfiles(this IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.AddMaps(typeof(ProductModelProfile));
        }
    }
}