
using AutoMapper;
using LibraryMgtApiApplication.Dto;
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Exceptions;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.AuthorBooks.Queries.GetBookByIdForAuthor
{
    public class GetBookByIdForAuthorQueryHandler : IRequestHandler<GetBookByIdForAuthorQuery, GetBookByIdForAuthorResponseDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetBookByIdForAuthorQueryHandler> _logger;
        public GetBookByIdForAuthorQueryHandler(IAuthorRepository authorRepository, IBookRepository bookRepository, IMapper mapper, ILogger<GetBookByIdForAuthorQueryHandler> logger)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<GetBookByIdForAuthorResponseDto> Handle(GetBookByIdForAuthorQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Getting book of Id: {request.Id} for author with id: {request.AuthorId}");

            var author = await _authorRepository.GetById( request.AuthorId );
            if (author == null) { throw new NotFoundException(nameof(Author), request.AuthorId.ToString()); }

            var book =  author.Books.FirstOrDefault(ab => ab.Id == request.Id);
            if (book == null) { throw new NotFoundException(nameof(Book), request.Id.ToString()); }

            var response = _mapper.Map<GetBookByIdForAuthorResponseDto>(book);

            return response;
        }
    }
}
