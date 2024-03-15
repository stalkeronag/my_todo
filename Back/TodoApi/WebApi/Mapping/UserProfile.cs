using AutoMapper;
using WebApi.Dto;
using WebApi.Models;

namespace WebApi.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));         
        }

    }
}
