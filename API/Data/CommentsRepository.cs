using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CommentsRepository : ICommentsRepo
    {
        private readonly ApplicationDbContext _context;

        public CommentsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteComment(Comment comment)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllComments(int threadId)
        {
            return await _context.Comments.Where(c=> c.ThreadId == threadId).ToListAsync();
        }

        public async Task<Comment> GetCommentByID(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(comment => comment.Id == id);
        }
    }
}
