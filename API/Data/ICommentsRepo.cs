using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public interface ICommentsRepo
    {
        Task<IEnumerable<Comment>> GetAllComments(int threadId);
        Task CreateComment(Comment comment);
        Task DeleteComment(Comment comment);
        Task<Comment> GetCommentByID(int id);
    }
}
