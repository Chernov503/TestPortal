using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Domain.Entityes
{
    public class UserTestAccessEntity
    {
        public Guid TestId { get; set; }
        public Guid UserId { get; set; }
    }
}
