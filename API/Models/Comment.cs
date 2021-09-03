using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(2200)]
        public string Content { get; set; }
        public Thread Thread { get; set; }
        [ForeignKey("Thread")]
        public int ThreadId { get; set; }
        [Required]
        public string UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
