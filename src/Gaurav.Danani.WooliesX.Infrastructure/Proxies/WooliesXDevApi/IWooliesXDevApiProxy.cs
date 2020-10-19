using System.Collections.Generic;
using System.Threading.Tasks;
using Gaurav.Danani.WooliesX.Infrastructure.Proxies.WooliesXDevApi.Dtos;
using Refit;

namespace Gaurav.Danani.WooliesX.Infrastructure.Proxies.WooliesXDevApi
{
    public interface IWooliesXDevApiProxy
    {
        [Get("/api/resource/products")]
        Task<IEnumerable<ProductDto>> GetProductsAsync([Query] string token);
        
        [Get("/api/resource/shopperHistory")]
        Task<IEnumerable<ShoppingHistoryDto>> GetShopperHistoryAsync([Query] string token);

        [Post("/api/resource/trolleyCalculator")]
        Task<double> GetTrolleyTotalAsync([Query] string token, [Body] GetTrolleyTotalDto getTrolleyTotalDto);
    }
}