
using LibraryMgtApiApplication.Dto;
using MediatR;

namespace LibraryMgtApiApplication.Authors.Queries.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<CreateAuthorResponseDto>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Biography { get; set; } = default!;
    }
}
