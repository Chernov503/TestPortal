﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Domain.Entityes
{
    public class SessionRedis //Redis
    {
        public string Key { get; set; }
        //Key = $"sessions:{UserId}"
        public string Company { get; set; }
        public int Role { get; set; }
    }
}
