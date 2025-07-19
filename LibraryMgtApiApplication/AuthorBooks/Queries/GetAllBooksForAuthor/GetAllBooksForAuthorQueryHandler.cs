
using AutoMapper;
using LibraryMgtApiApplication.Dto;
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Exceptions;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.Books.Queries.GetAllBooksForAuthor
{
    public class GetAllBooksForAuthorQueryHandler : IRequestHandler<GetAllBooksForAuthorQuery, IEnumerable<CreateNewBookForAuthorResponseDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllBooksForAuthorQueryHandler> _logger;
        public GetAllBooksForAuthorQueryHandler(IBookRepository bookRepository, IAuthorRepository authorRepository, IMapper mapper, ILogger<GetAllBooksForAuthorQueryHandler> logger)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _logger = logger;
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<CreateNewBookForAuthorResponseDto>> Handle(GetAllBooksForAuthorQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Getting All Books for author with AuthorId {request.AuthorId}");

            var author = await _authorRepository.GetById( request.AuthorId );
            if(author == null ) { throw new NotFoundException(nameof(Author), request.AuthorId.ToString());  }

            var allAuthorBooks = _mapper.Map<IEnumerable<CreateNewBookForAuthorResponseDto>>(author.Books);

            return allAuthorBooks;
        }


    }
}
