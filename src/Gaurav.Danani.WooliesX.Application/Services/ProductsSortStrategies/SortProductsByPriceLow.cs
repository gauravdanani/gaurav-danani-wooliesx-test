using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gaurav.Danani.WooliesX.Application.Common.Models;
using Gaurav.Danani.WooliesX.Application.Services.Interfaces;

namespace Gaurav.Danani.WooliesX.Application.Services.ProductsSortStrategies
{
    public class SortProductsByPriceLow : IProductsSortStrategy
    {
        public async Task<IEnumerable<ProductModel>> Sort(IEnumerable<ProductModel> products)
        {
            return await Task.FromResult(products.OrderBy(p => p.Price));
        }
    }
}