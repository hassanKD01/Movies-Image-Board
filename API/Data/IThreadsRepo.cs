using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface IThreadsRepo
    {
        Task<PaginatedList<Thread>> GetThreads(FilterModel filter);
        Task<Thread> GetThreadById(int id);
        Task<IEnumerable<Thread>> GetThreadsByUserID(string userid);
        Task CreateThread(Thread th);
        Task DeleteThread(Thread th);
    }
}
