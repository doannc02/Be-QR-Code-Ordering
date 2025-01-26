using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Models.Filter
{
    public class ParamsFindByCategory
    {
        public int CategoryId { get; set; }
        public string? Search { get; set; }
    }
}
