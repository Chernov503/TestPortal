using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Domain.Entityes
{
    public class BadLoginRecordRedis // Redis
    {
        public string Key { get; set; }
        //Key = $"bad_login:{email}"
        public int Count { get; set; }
    }
}
