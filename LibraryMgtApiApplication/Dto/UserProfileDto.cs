using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgtApiApplication.Dto
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string Bio { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;

        // Foreign Key
        public int UserId { get; set; }
    }
}
