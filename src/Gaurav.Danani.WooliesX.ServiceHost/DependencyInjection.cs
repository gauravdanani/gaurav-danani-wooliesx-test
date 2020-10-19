using FluentValidation;
using Gaurav.Danani.WooliesX.Application.Trolleys.Queries.GetTrolleyTotal;
using Gaurav.Danani.WooliesX.ServiceHost.Requests;
using Gaurav.Danani.WooliesX.ServiceHost.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Gaurav.Danani.WooliesX.ServiceHost
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceHost(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetProductsListRequest>, GetProductsListRequestValidator>();
            services.AddScoped<IValidator<TrolleyTotalRequest>, TrolleyTotalRequestValidator>();
            
            return services;
        }
    }
}