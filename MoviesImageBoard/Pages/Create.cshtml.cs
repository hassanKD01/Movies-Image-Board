using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesImageBoard.Services;
using MoviesImageBoard.ViewModels;

namespace MoviesImageBoard.Pages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ImageService _service;
        private readonly IClient _httpclient;

        public CreateModel(ImageService service, IClient httpclient)
        {
            _service = service;
            _httpclient = httpclient;
        }

        [BindProperty]
        public CreateThreadViewModel Input { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Choose an image")]
        public IFormFile Image { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string imageName = await _service.SavePicture(Image);

            Input.ImagePath = imageName;
            
            Input.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Input.Date = DateTime.Now;
            
            await _httpclient.PostThread(Input);
            
            return RedirectToPage("./Index");
        }
    }
}
