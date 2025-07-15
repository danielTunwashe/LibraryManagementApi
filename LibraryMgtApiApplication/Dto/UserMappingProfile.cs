using AutoMapper;
using LibraryMgtApiApplication.Uxar.Commands.CreateUser;
using LibraryMgtApiApplication.Uxar.Commands.UpdateUser;
using LibraryMgtApiApplication.UxarProfile.Commands.CreateProfile;
using LibraryMgtApiApplication.UxarProfile.Commands.UpdateProfile;
using LibraryMgtApiDomain.Entities;


namespace LibraryMgtApiApplication.Dto
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, CreateUserResponseDto>();
            CreateMap<User, GetUserByIdResponseDto>();
            CreateMap<UserProfile, UserProfileDto>();
            CreateMap<UserProfile, CreateProfileResponseDto>();
            CreateMap<UserProfile, UserProfileResponseDto>();


            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<CreateProfileCommand, UserProfile>();
            CreateMap<UpdateUserProfileCommand, UserProfile>();
        }
    }
}
