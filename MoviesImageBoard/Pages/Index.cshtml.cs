using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviesImageBoard.Services;
using MoviesImageBoard.ViewModels;

namespace MoviesImageBoard.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IClient _httpclient;

        public IndexModel(IClient httpclient)
        {
            _httpclient = httpclient;
        }

        public ViewPaginatedList<ListThreadsViewModel> Threads { get; set; }

        [BindProperty(SupportsGet =true)]
        public string Category { get; set; }

        [BindProperty(SupportsGet =true)]
        [Required(ErrorMessage ="Enter the name of the movie")]
        [Display(Name ="Movie Name")]
        public string MovieName { get; set; }

        public async Task OnGet(int? pageNumber)
        {
            // ?? verifies if variable is null if true it returns an empty string in this case
            ViewData["CurrentFilter"] = Category ?? "";
            ViewData["SearchString"] = MovieName ?? "";

            int pageSize = 12;
            
            Threads = await _httpclient.GetListThreads(pageNumber?? 1,pageSize,Category ?? "",MovieName ?? "");
        }
    }
}
