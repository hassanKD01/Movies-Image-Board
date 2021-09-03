using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class FilterModel
    {
        public int Page { get; set; }
        public int Limit { get; set; }
        public string Category { get; set; }
        public string MovieName { get; set; }
        public FilterModel()
        {
            this.Page = 1;
            this.Limit = 12;
        }
    }
}
