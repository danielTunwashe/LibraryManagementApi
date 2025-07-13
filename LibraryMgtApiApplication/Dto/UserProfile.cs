using AutoMapper;
using LibraryMgtApiApplication.Uxar.Commands.CreateUser;
using LibraryMgtApiDomain.Entities;


namespace LibraryMgtApiApplication.Dto
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, CreateUserResponseDto>();

            CreateMap<CreateUserCommand, User>();
        }
    }
}
