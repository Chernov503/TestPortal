using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Domain.Entityes
{
    public class BadLoginRecordEntity // Redis
    {
        public string Key { get; set; } = "bad_login:";
        public int Count { get; set; }
    }
}
