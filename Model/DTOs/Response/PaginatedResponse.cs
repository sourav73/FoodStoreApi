using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs.Response
{
    public class PaginatedResponse<T>
    {
        public List<T> Data { get; set; }
        public string? Message { get; set; }
        public int Count { get; set; }
    }
}
