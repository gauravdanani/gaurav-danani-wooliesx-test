using AutoMapper;
using Gaurav.Danani.WooliesX.Application.Trolleys.Queries.GetTrolleyTotal;
using Gaurav.Danani.WooliesX.Infrastructure.Proxies.WooliesXDevApi.Dtos;

namespace Gaurav.Danani.WooliesX.Infrastructure.MappingProfiles
{
    public class GetTrolleyTotalDtoProfile : Profile
    {
        public GetTrolleyTotalDtoProfile()
        {
            CreateMap<TrolleyProduct, TrolleyProductDto>();
            CreateMap<TrolleyQuantity, TrolleyQuantityDto>();
            CreateMap<Special, SpecialDto>();
            CreateMap<TrolleyTotalRequest, GetTrolleyTotalDto>();
        }
    }
}