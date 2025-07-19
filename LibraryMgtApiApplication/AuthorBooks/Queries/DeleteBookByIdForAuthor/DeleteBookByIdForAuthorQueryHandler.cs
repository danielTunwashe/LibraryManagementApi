using AutoMapper;
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Exceptions;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgtApiApplication.AuthorBooks.Queries.DeleteBookByIdForAuthor
{
    public class DeleteBookByIdForAuthorQueryHandler : IRequestHandler<DeleteBookByIdForAuthorQuery>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteBookByIdForAuthorQueryHandler> _logger;

        public DeleteBookByIdForAuthorQueryHandler(IAuthorRepository authorRepository, IBookRepository bookRepository, IMapper mapper, ILogger<DeleteBookByIdForAuthorQueryHandler> logger)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(DeleteBookByIdForAuthorQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Deleting Book of id {request.Id} For Author with Id: {request.AuthorId}");
            
            var author = await _authorRepository.GetById(request.AuthorId);

            if (author == null)
            {
                throw new NotFoundException(nameof(Author), request.AuthorId.ToString());
            }

            var book = author.Books.FirstOrDefault(ab => ab.Id == request.Id);

            await _bookRepository.Delete(book);

        }
    }
}
