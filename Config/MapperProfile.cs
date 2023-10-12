using AutoMapper;
using UmbracoMekashronApplication.DTO;
using UmbracoMekashronApplication.model;

namespace UmbracoMekashronApplication.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginReponse, LoginResponseDTO>();
            CreateMap<LoginResponseDTO, LoginReponse>();
        }
    }
}
