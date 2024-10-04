using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.V1.DTOs
{
    public class SmtpSetting
    {
        public string? SmtpServer { get; set; }
        public string? UserName { get; set; }
        public string? AppName { get; set; }
        public string? Password { get; set; }
        public int Port { get; set; }
        public string? From { get; set; }
    }
}
