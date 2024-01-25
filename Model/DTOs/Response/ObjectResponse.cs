using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs.Response
{
    public class ObjectResponse<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
