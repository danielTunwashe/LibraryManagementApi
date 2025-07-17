using LibraryMgtApiApplication.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgtApiApplication.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<GetAuthorByIdResponseDto>
    {
        public GetAuthorByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

}

