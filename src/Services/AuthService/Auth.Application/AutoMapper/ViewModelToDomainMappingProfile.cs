using Auth.Application.DTOs;
using Auth.Domain.Entities;
using Auth.Domain.ValueObjects;
using AutoMapper;

namespace Auth.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => new Email(src.Email)))
                .ForMember(dest => dest.Senha, opt => opt.Ignore());
        }
    }
}
