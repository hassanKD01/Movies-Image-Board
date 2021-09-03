using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesImageBoard.Services;
using MoviesImageBoard.ViewModels;

namespace MoviesImageBoard.Areas.Identity.Pages.Account.Manage
{
    public class MyThreadsModel : PageModel
    {
        private readonly IClient _httpclient;

        public MyThreadsModel(IClient httpclient)
        {
            _httpclient = httpclient;
        }

        public IEnumerable<ListThreadsViewModel> Threads { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Threads = await _httpclient.GetThreadsByUserID(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Page();
        }

        [BindProperty]
        public int id { get; set; }

        public async Task<IActionResult> OnPost()
        {
            await _httpclient.DeleteThread(id);
            return await this.OnGet();
        }
    }
}
