using AutoMapper;
using TeploBalanceKotelCore.Data;
using TeploBalanceKotelCore.Models;

namespace TeploBalanceKotelCore
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<VariantAddDto, VarTverdToplivo>();
            CreateMap<VariantUserTverdAddDtoModel, DataInputVariant_TverdToplivo>();
        }
    }
}
