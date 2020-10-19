using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gaurav.Danani.WooliesX.Application.Common.Interfaces;
using Gaurav.Danani.WooliesX.Application.Common.Models;
using Gaurav.Danani.WooliesX.Application.Services.Interfaces;

namespace Gaurav.Danani.WooliesX.Application.Services.ProductsSortStrategies
{
    public class SortProductsByRecommended : IProductsSortStrategy
    {
        private readonly IProductService _productService;

        public SortProductsByRecommended(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IEnumerable<ProductModel>> Sort(IEnumerable<ProductModel> products)
        {
            var shoppedProducts = await _productService.GetProductsShoppingHistoryAsync();
            return from product in products
                join shoppedProduct in shoppedProducts on product.Name equals shoppedProduct.Name into productHistoryGroup
                from subProduct in productHistoryGroup.DefaultIfEmpty()
                orderby subProduct?.TotalQuantitySold descending, subProduct?.TotalQuantitySold descending
                select product;
        }
    }
}