using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MoviesImageBoard.ViewModels
{
    public class CreateThreadViewModel
    {
        [Required(ErrorMessage ="A title for the thread is required.")]
        [Display(Name ="Thread Title")]
        [MaxLength(150)]
        public string Title { get; set; }

        [Display(Name ="Movie Title")]
        [Required(ErrorMessage ="The movie's title is required")]
        public string MovieName { get; set; }

        [Display(Name ="Your Thoughts")]
        [MaxLength(2200)]
        public string Content { get; set; }

        public DateTime Date { get; set; }

        public string ImagePath { get; set; }

        [Required(ErrorMessage ="Choose a category for the movie")]
        public string Category { get; set; }

        public string UserId { get; set; }
    }
}
