using AutoMapper;
using Gaurav.Danani.WooliesX.Application.Common.Models;
using Gaurav.Danani.WooliesX.Infrastructure.Proxies.WooliesXDevApi.Dtos;

namespace Gaurav.Danani.WooliesX.Infrastructure.MappingProfiles
{
    public class ProductModelProfile : Profile
    {
        public ProductModelProfile()
        {
            CreateMap<ProductDto, ProductModel>();
        }
    }
}