using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServce.Application.JWT
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public double ExpiresHours { get; set; }
    }
}
