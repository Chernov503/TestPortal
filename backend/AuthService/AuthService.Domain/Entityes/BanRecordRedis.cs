using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Domain.Entityes
{
    public class BanRecordRedis
    {
        public string Key {  get; set; }
        //Key = $"baned_users:{email}"
        public string Message { get; set; }

    }
}
