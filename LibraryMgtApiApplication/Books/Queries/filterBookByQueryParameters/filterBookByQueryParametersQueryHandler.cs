

using AutoMapper;
using LibraryMgtApiApplication.Dto;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.Books.Queries.filterBookByQueryParameters
{
    public class filterBookByQueryParametersQueryHandler : IRequestHandler<filterBookByQueryParametersQuery, IEnumerable<filteredBookResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<filterBookByQueryParametersQueryHandler> _logger;
        private readonly IBookRepository _bookRepository;

        public filterBookByQueryParametersQueryHandler(IMapper mapper, ILogger<filterBookByQueryParametersQueryHandler> logger, IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<filteredBookResponseDto>> Handle(filterBookByQueryParametersQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Getting filtered book based on {request.Title}, {request.AuthorName} and {request.GenreName}");

            var query = await _bookRepository.GetFilteredBook(request.Title, request.AuthorName, request.GenreName);

            var response = _mapper.Map<IEnumerable<filteredBookResponseDto>>(query);

            return response;
        }
    }
}
