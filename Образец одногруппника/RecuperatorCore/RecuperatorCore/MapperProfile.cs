using AutoMapper;
using RecuperatorCore.Models;
using RecuperatorLibrary.Models;

namespace RecuperatorCore
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<VariantAddDto, Variant>();
            CreateMap<UserAddDto, User>();
            CreateMap<VariantUserAddDto, VariantUser>();
        }
    }
}
