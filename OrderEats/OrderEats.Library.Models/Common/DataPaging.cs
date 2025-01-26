using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Models.Common
{
    /// <summary>
    /// collection of object return
    /// </summary>
    public class DataPaging
    {
        public IEnumerable<object> Data { get; set; }
        public int TotalPage { get; set; }
    }

    /// <summary>
    /// Datapaging by T object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataPaging<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalPage { get; set; }
    }
}
