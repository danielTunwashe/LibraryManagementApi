
using AutoMapper;
using LibraryMgtApiApplication.Dto;
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Exceptions;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.Authors.Queries.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, CreateAuthorResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<UpdateAuthorCommandHandler> _logger;
        public UpdateAuthorCommandHandler(IMapper mapper, IAuthorRepository authorRepository, ILogger<UpdateAuthorCommandHandler> logger)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<CreateAuthorResponseDto> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            
            _logger.LogInformation($"Updating Author with Id: {request.Id}");
            
            var author = await _authorRepository.GetById(request.Id);
            if (author == null)
            {
                throw new NotFoundException(nameof(author), request.Id.ToString());
            }

            // Map request fields onto the tracked author instance
            _mapper.Map(request, author);

            var updatedAuthor = await _authorRepository.Update(author);

            var newMappedAuthor = _mapper.Map<CreateAuthorResponseDto>(updatedAuthor);

            return newMappedAuthor;

        }
    }
}
