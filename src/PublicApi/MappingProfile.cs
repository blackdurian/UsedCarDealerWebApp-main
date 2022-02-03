using AutoMapper;
using Microsoft.UsedCarDealerWeb.ApplicationCore.Entities;
using Microsoft.UsedCarDealerWeb.PublicApi.CatalogBrandEndpoints;
using Microsoft.UsedCarDealerWeb.PublicApi.CatalogItemEndpoints;
using Microsoft.UsedCarDealerWeb.PublicApi.CatalogTypeEndpoints;

namespace Microsoft.UsedCarDealerWeb.PublicApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CatalogItem, CatalogItemDto>();
        CreateMap<CatalogType, CatalogTypeDto>()
            .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Type));
        CreateMap<CatalogBrand, CatalogBrandDto>()
            .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Brand));
    }
}
