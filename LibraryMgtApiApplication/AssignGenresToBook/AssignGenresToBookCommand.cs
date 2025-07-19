using LibraryMgtApiDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgtApiApplication.AssignGenresToBook
{
    public class AssignGenresToBookCommand : IRequest
    {
        public int BookId { get; set; }

        public List<int> GenreIds { get; set; } = new List<int>();
    }
}
