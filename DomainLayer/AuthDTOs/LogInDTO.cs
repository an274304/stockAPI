using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.AuthDTOs
{
    public class LogInDTO
    {
        public string email { get; set; }
        public string password { get; set; }
        public Boolean isRemember { get; set; }
    }
}
