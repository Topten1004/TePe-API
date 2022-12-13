using AutoMapper;
using Tepe.Brt.Api.ViewModels;
using Tepe.Brt.Data;
using Tepe.Brt.Data.Entities;

namespace Tepe.Brt.Api
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PatientEntity, PatientVM>().ReverseMap();
            CreateMap<RecommendationEntity, RecommendationVM>().ReverseMap();
            CreateMap<RecoItemEntity, RecoItemVM>().ReverseMap();
            CreateMap<CategoryEntity, CategoryVM>().ReverseMap();
            CreateMap<ProductEntity, ProductVM>().ReverseMap();
            CreateMap<MarketEntity, MarketVM>().ReverseMap();
        }
    }
}
