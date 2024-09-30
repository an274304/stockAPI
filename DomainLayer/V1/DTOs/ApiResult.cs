using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.V1.DTOs
{
    public class ApiResult<T>
    {
        public string? message { get; set; }
        public bool? result { get; set; }
        public T? data { get; set; }
        public List<T>? dataList { get; set; }
    }
}
