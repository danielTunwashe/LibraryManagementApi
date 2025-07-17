
using AutoMapper;
using LibraryMgtApiApplication.Dto;
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, CreateAuthorResponseDto>
    {
        private readonly ILogger<CreateAuthorCommandHandler> _logger;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public CreateAuthorCommandHandler(ILogger<CreateAuthorCommandHandler> logger, IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<CreateAuthorResponseDto> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Creating a new author with Name: {request.Name}");

            var mappedAuthor = _mapper.Map<Author>(request);

            var author = await _authorRepository.Create(mappedAuthor);

            var newMappedAuthor = _mapper.Map<CreateAuthorResponseDto>(author);

            return newMappedAuthor;
        }
    }
}
