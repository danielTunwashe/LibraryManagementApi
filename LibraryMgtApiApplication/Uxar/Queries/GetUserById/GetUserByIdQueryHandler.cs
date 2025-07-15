

using AutoMapper;
using LibraryMgtApiApplication.Dto;
using LibraryMgtApiDomain.Exceptions;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.Uxar.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserByIdQueryHandler> _logger;
        public GetUserByIdQueryHandler(IUserRepository userRepository,IMapper mapper, ILogger<GetUserByIdQueryHandler> logger)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<GetUserByIdResponseDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Getting user with Id: {request.Id}");
             var user = await _userRepository.GetById(request.Id);
            if (user == null) throw new NotFoundException(nameof(GetUserByIdQuery), request.Id.ToString()); 

            var mappedUser = _mapper.Map<GetUserByIdResponseDto>(user);

            return mappedUser;
        }
    }
}
