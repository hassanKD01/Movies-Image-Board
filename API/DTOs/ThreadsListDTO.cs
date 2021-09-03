using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ThreadsListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MovieName { get; set; }
        public string ImagePath { get; set; }
    }
}
