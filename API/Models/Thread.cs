using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Thread
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        [MaxLength(2200)]
        public string Content { get; set; }
        [Required]
        [MaxLength(150)]
        public string MovieName { get; set; }
        public ICollection<Comment> Comments { get; set; }
        [MaxLength(150)]
        public string ImagePath { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string CategoryFK { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
