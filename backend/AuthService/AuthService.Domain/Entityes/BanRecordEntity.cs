using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Domain.Entityes
{
    public class BanRecordEntity //PostgreSQL
    {
        public string Email { get; set; }
        public string BanMessage { get; set; }
        public DateTime DateExp { get; set; }
    }
}
