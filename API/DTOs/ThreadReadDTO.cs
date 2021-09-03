using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ThreadReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string MovieName { get; set; }
        public ICollection<CommentReadDTO> Comments { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        public string CategoryFK { get; set; }
        public string UserId { get; set; }
    }
}
