using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Gaurav.Danani.WooliesX.Application.Common.Interfaces;
using Gaurav.Danani.WooliesX.Application.Common.Models;
using Gaurav.Danani.WooliesX.Infrastructure.Proxies.WooliesXDevApi;
using Microsoft.Extensions.Logging;
using Refit;

namespace Gaurav.Danani.WooliesX.Infrastructure.Services
{
    //TODO: Use Polly with Retry And/Or CircuitBreaker policy.
    public class ProductService : IProductService
    {
        private readonly IWooliesXDevApiProxy _wooliesXDevApiProxy;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;
        private readonly string _token;

        public ProductService(
            IWooliesXDevApiProxy wooliesXDevApiProxy,
            IAppSettingsProvider appSettingsProvider,
            IMapper mapper,
            ILogger<ProductService> logger)
        {
            _wooliesXDevApiProxy = wooliesXDevApiProxy;
            _mapper = mapper;
            _logger = logger;
            _token = appSettingsProvider.AppSettings.Proxies.WooliesXDevApi.Token;
        }

        public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
        {
            try
            {
                var products = await _wooliesXDevApiProxy.GetProductsAsync(_token);

                return _mapper.Map<IEnumerable<ProductModel>>(products);
            }
            catch (ApiException e)
            {
                _logger.LogError(e, "WooliesXDevApi: GetProductsAsync operation failed.");
                throw;
            }
        }

        public async Task<IEnumerable<ProductHistoryModel>> GetProductsShoppingHistoryAsync()
        {
            try
            {
                var shopperHistory = await _wooliesXDevApiProxy.GetShopperHistoryAsync(_token);

                var products = shopperHistory.SelectMany(r => r.Products);
            
                return products.GroupBy(p => p.Name)
                    .Select(g => new ProductHistoryModel
                    {
                        Name = g.Key,
                        NumberOfCustomerPurchases = g.Count(),
                        TotalQuantitySold = g.Sum(p => p.Quantity)
                    });
            }
            catch (ApiException e)
            {
                _logger.LogError(e, "WooliesXDevApi: GetShopperHistoryAsync operation failed.");
                throw;
            }
        }
    }
}