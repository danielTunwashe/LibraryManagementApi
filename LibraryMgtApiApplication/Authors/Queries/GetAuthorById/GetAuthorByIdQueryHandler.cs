using AutoMapper;
using LibraryMgtApiApplication.Dto;
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Exceptions;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.Authors.Queries.GetAuthorById
{

    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetAuthorByIdQueryHandler> _logger;    
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorByIdQueryHandler(IMapper mapper, ILogger<GetAuthorByIdQueryHandler> logger, IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetAuthorByIdResponseDto?> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Getting Author with Id: {request.Id}");

            var author = await _authorRepository.GetById(request.Id);

            var mappedAuthor = _mapper.Map<GetAuthorByIdResponseDto>(author);
            if (mappedAuthor == null)
            {
                throw new NotFoundException(nameof(Author),request.Id.ToString());
            }

            return mappedAuthor;
        }
    }
}
