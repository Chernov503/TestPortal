using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Domain.Entityes
{
    public class SessionEntity //Redis
    {
        public Guid UserId { get; set; }
        public string Company { get; set; }
        public int Role { get; set; }
    }
}
