using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Domain.Entityes
{
    public class UserEntity //PostgreSQL
    {
        public Guid Id { get; init; }
        public string Firstname { get; init; }
        public string Surname { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string Company { get; init; }
        public int Role { get; init; }
    }
}
