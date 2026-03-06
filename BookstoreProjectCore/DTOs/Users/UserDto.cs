using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.DTOs.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
    }
}
