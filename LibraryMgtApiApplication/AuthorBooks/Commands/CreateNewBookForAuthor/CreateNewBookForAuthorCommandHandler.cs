using AutoMapper;
using LibraryMgtApiApplication.Dto;
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.AuthorBooks.Commands.CreateNewBookForAuthor
{
    public class CreateNewBookForAuthorCommandHandler : IRequestHandler<CreateNewBookForAuthorCommand, CreateNewBookForAuthorResponseDto>
    {
        
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateNewBookForAuthorCommandHandler> _logger;

        public CreateNewBookForAuthorCommandHandler(IBookRepository bookRepository, IMapper mapper, ILogger<CreateNewBookForAuthorCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreateNewBookForAuthorResponseDto> Handle(CreateNewBookForAuthorCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Creating Book with title {request.Title} for author with AuthorId: {request.AuthorId}");

            var mappedBook = _mapper.Map<Book>(request);

            var createdBook = await _bookRepository.Create(mappedBook);
            
            var response = _mapper.Map<CreateNewBookForAuthorResponseDto>(createdBook);

            return response;
        }



    }
}
