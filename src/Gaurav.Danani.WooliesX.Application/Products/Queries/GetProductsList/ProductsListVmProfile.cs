using AutoMapper;
using Gaurav.Danani.WooliesX.Application.Common.Models;

namespace Gaurav.Danani.WooliesX.Application.Products.Queries.GetProductsList
{
    public class ProductsListVmProfile : Profile
    {
        public ProductsListVmProfile()
        {
            CreateMap<ProductModel, ProductsListVm>();
        }
    }
}