using LibraryMgtApiApplication.Dto;
using MediatR;

namespace LibraryMgtApiApplication.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<CreateAuthorResponseDto>
    {
        public string Name { get; set; } = default!;
        public string Biography { get; set; } = default!;
    }
}
