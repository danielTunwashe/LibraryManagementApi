using AutoMapper;
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Exceptions;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.Authors.Queries.DeleteAuthor
{
    public class DeleteAuthorCommandQueryHandler : IRequestHandler<DeleteAuthorCommandQuery>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteAuthorCommandQueryHandler> _logger;  
        public DeleteAuthorCommandQueryHandler(IAuthorRepository authorRepository, IMapper mapper, ILogger<DeleteAuthorCommandQueryHandler> logger)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task Handle(DeleteAuthorCommandQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Deleting Author Profile with Id: {request.Id}");

            var author = await _authorRepository.GetById(request.Id);
            if (author == null)
            {
                throw new NotFoundException(nameof(Author), request.Id.ToString());
            }

            await _authorRepository.Delete(author);
        }
    }
}
