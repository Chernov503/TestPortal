using AuthService.Contracts.Requests;
using AuthService.Contracts.Responses;
using AuthService.Domain.Entityes;
using AutoMapper;

namespace AuthServce.Application.Mappers
{
    public class AuthMapperProfile : Profile
    {
        public AuthMapperProfile()
        {
            CreateMap<RegisterRequest, UserServiceRegistrationRequest>().ReverseMap();
            CreateMap<UserServiceRegistrationResponse, SessionRedis>();
        }
    }
}
