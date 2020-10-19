using System.Reflection;
using AutoMapper;
using Gaurav.Danani.WooliesX.Application.ApplicationSettings;
using Gaurav.Danani.WooliesX.Application.Common.Interfaces;
using Gaurav.Danani.WooliesX.Application.Products.Queries.GetProductsList;
using Gaurav.Danani.WooliesX.Application.Services.Interfaces;
using Gaurav.Danani.WooliesX.Application.Services.ProductsSortStrategies;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Gaurav.Danani.WooliesX.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IAppSettingsProvider, AppSettingsProvider>();
            services.AddScoped<IProductsSortFactory, ProductsSortFactory>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            return services;
        }
        
        public static void AddApplicationMappingProfiles(this IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.AddMaps(typeof(ProductsListVm));
        }
    }
}