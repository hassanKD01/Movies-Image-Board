using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CommentReadDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
