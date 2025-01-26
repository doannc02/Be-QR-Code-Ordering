using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Models.Response
{
    public class ResponseObject
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class ResponseObject<T>
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
