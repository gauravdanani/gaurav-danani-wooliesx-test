using System;
using Gaurav.Danani.WooliesX.Application.Common.Interfaces;
using Gaurav.Danani.WooliesX.Application.Services.Interfaces;

namespace Gaurav.Danani.WooliesX.Application.Services.ProductsSortStrategies
{
    public class ProductsSortFactory : IProductsSortFactory
    {
        private readonly IProductService _productService;

        public ProductsSortFactory(IProductService productService)
        {
            _productService = productService;
        }
        
        public IProductsSortStrategy GetProductsSortStrategy(string sortOption)
        {
            //TODO: Create Enum for SortOption
            switch (sortOption.ToLower())
            {
                case "low":
                    return new SortProductsByPriceLow();
                case "high":
                    return new SortProductsByPriceHigh();
                case "ascending":
                    return new SortProductsByNameAscending();
                case "descending":
                    return new SortProductsByNameDescending();
                case "recommended":
                    return new SortProductsByRecommended(_productService);
                default:
                    return new SortProductsByPriceLow();
            }
        }
    }
}