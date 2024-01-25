using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs.Response
{
    public class ListResponse<T>
    {
        public string Message { get; set; }
        public List<T> Data { get; set; }
    }
}
