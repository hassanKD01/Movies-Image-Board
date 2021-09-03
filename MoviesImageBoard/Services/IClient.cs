using System.Collections.Generic;
using System.Threading.Tasks;
using MoviesImageBoard.ViewModels;

namespace MoviesImageBoard.Services
{
    public interface IClient
    {
        Task DeleteComment(int id);
        Task DeleteThread(int id);
        Task<IEnumerable<CommentViewModel>> GetComments();
        Task<ThreadViewModel> GetThreadById(int id);
        Task<IEnumerable<ListThreadsViewModel>> GetThreadsByUserID(string userid);
        Task<ViewPaginatedList<ListThreadsViewModel>> GetListThreads(
            int page, int limit,
            string category, string movieName
            );
        Task<string> PostComment(CommentCreateViewModel viewModel);
        Task<string> PostThread(CreateThreadViewModel model);
    }
}