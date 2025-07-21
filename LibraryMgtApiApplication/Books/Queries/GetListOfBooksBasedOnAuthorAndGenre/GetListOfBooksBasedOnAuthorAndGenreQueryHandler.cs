

using AutoMapper;
using LibraryMgtApiApplication.Dto;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.Books.Queries.GetListOfBooksBasedOnAuthorAndGenre
{
    public class GetListOfBooksBasedOnAuthorAndGenreQueryHandler : IRequestHandler<GetListOfBooksBasedOnAuthorAndGenreQuery, IEnumerable<GetAllListOfBooksForAuthorResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<GetListOfBooksBasedOnAuthorAndGenreQueryHandler> _logger;
        public GetListOfBooksBasedOnAuthorAndGenreQueryHandler(IMapper mapper, IAuthorRepository authorRepository, 
            IBookRepository bookRepository, ILogger<GetListOfBooksBasedOnAuthorAndGenreQueryHandler> logger)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<GetAllListOfBooksForAuthorResponseDto>> Handle(GetListOfBooksBasedOnAuthorAndGenreQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Getting list of books based on author with name: {request.AuthorName} and genre with name {request.GenreName}");

            var book = await _bookRepository.GetBookByAuthorOrGenre(request.AuthorName, request.GenreName);

            var mappedBook = _mapper.Map<IEnumerable<GetAllListOfBooksForAuthorResponseDto>>(book);

            return mappedBook;
        }
    }
}
