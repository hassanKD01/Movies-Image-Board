using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesImageBoard.Services;
using MoviesImageBoard.ViewModels;

namespace MoviesImageBoard.Pages
{
    [Authorize]
    public class ThreadModel : PageModel
    {
        private readonly IClient _httpclient;
        private readonly UserManager<IdentityUser> _userManager;

        public ThreadModel(IClient httpclient, UserManager<IdentityUser> userManager)
        {
            _httpclient = httpclient;
            _userManager = userManager;
        }

        [BindProperty]
        public int CommentId { get; set; }

        [BindProperty(SupportsGet =true)]
        public int id { get; set; }
        public ThreadViewModel Thread { get; set; }
        public string Userid { get; set; }

        [BindProperty]
        public CommentCreateViewModel Input { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Thread = await _httpclient.GetThreadById(id);
            Userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Input.Date = DateTime.Now;
            Input.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _httpclient.PostComment(Input);
            return await this.OnGet();
        }

        public async Task<IActionResult> OnPostDeleteComment()
        {
            await _httpclient.DeleteComment(CommentId);
            return await this.OnGet();
        }
    }
}
