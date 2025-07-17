
using AutoMapper;
using LibraryMgtApiApplication.Dto;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.Authors.Queries.GetAllAuthors
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<GetAllAuthorsResponseDto>>
    {
        private readonly ILogger<GetAllAuthorsQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        public GetAllAuthorsQueryHandler(ILogger<GetAllAuthorsQueryHandler> logger, IMapper mapper, IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllAuthorsResponseDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting all authors..");

            var authors = await _authorRepository.GetAll();

            var mappedAuthor = _mapper.Map<IEnumerable<GetAllAuthorsResponseDto>>(authors);

            return mappedAuthor;

        }


    }
}
