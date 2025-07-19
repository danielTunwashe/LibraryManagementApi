using AutoMapper;
using LibraryMgtApiApplication.Dto;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgtApiApplication.Genreses.Queries.GetGenreById
{
    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, GenreResponseDto>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetGenreByIdQueryHandler> _logger;

        public GetGenreByIdQueryHandler(IGenreRepository genreRepository, IMapper mapper, ILogger<GetGenreByIdQueryHandler> logger)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
            _logger = logger;

        }
        public async Task<GenreResponseDto> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Getting Genre By Id for genre with id: {request.Id}");

            var genre = await _genreRepository.GetById(request.Id);

            var mappedGenre = _mapper.Map<GenreResponseDto>(genre);

            return mappedGenre;

        }
    }
}
