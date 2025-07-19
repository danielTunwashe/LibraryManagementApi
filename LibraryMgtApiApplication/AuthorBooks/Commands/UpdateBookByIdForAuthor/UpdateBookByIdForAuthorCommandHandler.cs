
using AutoMapper;
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Exceptions;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.AuthorBooks.Commands.UpdateBookByIdForAuthor
{
    public class UpdateBookByIdForAuthorCommandHandler : IRequestHandler<UpdateBookByIdForAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateBookByIdForAuthorCommandHandler> _logger;

        public UpdateBookByIdForAuthorCommandHandler(IAuthorRepository authorRepository, IBookRepository bookRepository, IMapper mapper, ILogger<UpdateBookByIdForAuthorCommandHandler> logger)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task Handle(UpdateBookByIdForAuthorCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Updating Book with Id {request.Id} for author with id {request.AuthorId}");

            var author = await _authorRepository.GetById( request.AuthorId );
            if(author == null) {throw new NotFoundException(nameof(Author), request.AuthorId.ToString()); }

            var book =  author.Books.FirstOrDefault(ab=>ab.Id == request.Id);
            if(book == null) { throw new NotFoundException(nameof(Book), request.Id.ToString()); }

            var mappedBook = _mapper.Map(request, book);

            await _bookRepository.Update(mappedBook);

        }




    }
}
