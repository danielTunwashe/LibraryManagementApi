
using AutoMapper;
using LibraryMgtApiApplication.Dto;
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Exceptions;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.Books.Queries.GetAllListOfBooksForAuthor
{
    public class GetAllListOfBooksForAuthorQueryHandler : IRequestHandler<GetAllListOfBooksForAuthorQuery, IEnumerable<GetAllListOfBooksForAuthorResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<GetAllListOfBooksForAuthorQueryHandler> _logger;
        public GetAllListOfBooksForAuthorQueryHandler(IMapper mapper, IAuthorRepository authorRepository, IBookRepository bookRepository, ILogger<GetAllListOfBooksForAuthorQueryHandler> logger)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<GetAllListOfBooksForAuthorResponseDto>> Handle(GetAllListOfBooksForAuthorQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Getting list of books for author with name: {request.AuthorName}");

            var author = await _authorRepository.GetByName(request.AuthorName);
            if (author == null) { throw new NotFoundException(nameof(Author), request.AuthorName.ToString()); }

            var authorListofBooks = author.Books.AsEnumerable();

            var mappedAuthorListOfBooks = _mapper.Map<IEnumerable<GetAllListOfBooksForAuthorResponseDto>>(authorListofBooks);

            return mappedAuthorListOfBooks;
        }
    }
}
