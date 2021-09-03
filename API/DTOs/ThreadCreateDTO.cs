using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace API.DTOs
{
    public class ThreadCreateDTO
    {
        public string Title { get; set; }

        public string MovieName { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public string ImagePath { get; set; }

        public string Category { get; set; }

        public string UserId { get; set; }
    }
}
