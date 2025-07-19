using AutoMapper;
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Exceptions;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgtApiApplication.AssignGenresToBook
{
    public class AssignGenresToBookCommandHandler : IRequestHandler<AssignGenresToBookCommand>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AssignGenresToBookCommandHandler> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;

        public AssignGenresToBookCommandHandler(IGenreRepository genreRepository, ILogger<AssignGenresToBookCommandHandler> logger, IBookRepository bookRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _logger = logger;
            _bookRepository = bookRepository;
            _mapper = mapper;

        }


        public async Task Handle(AssignGenresToBookCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Assigning genres with id's to book with id: {request.BookId}");

            var book = await _bookRepository.GetById( request.BookId );
            if (book == null) { throw new NotFoundException(nameof(Book), request.BookId.ToString());  }

            //This fetches all Genre entities from the database whose Id is in the list request.GenreIds.
            //It may return fewer genres than IDs passed if some IDs are invalid
            var genres = await _genreRepository.GetById(request.GenreIds);

            //If no genres are found at all, it means all the IDs provided are invalid.
            if (!genres.Any())
            {
                throw new ValidationException("None of the provided genre IDs exist.");
            }

            //We extract the IDs of the valid genres we found from the DB.
            //Convert to HashSet for fast lookup during comparison.
            var foundGenreIds = genres.Select(g => g.Id).ToHashSet();

            //We compare the original list of genre IDs (request.GenreIds) with what was found in the DB
            //Except() gives us the list of IDs that were requested but not found in the database — i.e., the invalid ones.
            var invalidGenreIds = request.GenreIds.Except(foundGenreIds).ToList();

            //If there are any invalid genre IDs, we throw another validation exception.
            //This one is more specific, telling the user exactly which genre IDs were wrong — e.g., "Invalid genre IDs: 5, 8"
            if (invalidGenreIds.Any())
            {
                throw new ValidationException($"Invalid genre IDs: {string.Join(", ", invalidGenreIds)}");
            }

            foreach ( var genre in genres )
            {
                book.BookGenres.Add(new BookGenre { BookId = book.Id, GenreId = genre.Id, });
            }

            await _bookRepository.Update(book);
        }
    }
}
