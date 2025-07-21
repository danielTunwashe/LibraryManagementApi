using AutoMapper;
using LibraryMgtApiApplication.AuthorBooks.Commands.CreateNewBookForAuthor;
using LibraryMgtApiApplication.AuthorBooks.Commands.UpdateBookByIdForAuthor;
using LibraryMgtApiApplication.Authors.Commands.CreateAuthor;
using LibraryMgtApiApplication.Authors.Queries.UpdateAuthor;
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
            CreateMap<Author, CreateAuthorResponseDto>();
            CreateMap<Author, GetAllAuthorsResponseDto>();
            CreateMap<Author, GetAuthorByIdResponseDto>();
            CreateMap<Book, GetAuthorByIdBookResponseDto>();
            CreateMap<BookGenre, GetAuthorByIdBookGenreResponseDto>();
            CreateMap<Book, CreateNewBookForAuthorResponseDto>();
            CreateMap<BookGenre, BookGenreDto>();
            CreateMap<Book, GetBookByIdForAuthorResponseDto>();
            CreateMap<Genre, GenreResponseDto>();
            CreateMap<Author, AuthorDto>();
            CreateMap<Book, filteredBookResponseDto>();
            CreateMap<Book, GetAllListOfBooksForAuthorResponseDto>();




            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<CreateProfileCommand, UserProfile>();
            CreateMap<UpdateUserProfileCommand, UserProfile>();
            CreateMap<CreateAuthorCommand, Author>();
            CreateMap<UpdateAuthorCommand, Author>();
            CreateMap<CreateNewBookForAuthorCommand, Book>();
            CreateMap<UpdateBookByIdForAuthorCommand, Book>();

        }
    }
}
