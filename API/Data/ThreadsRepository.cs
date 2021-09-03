using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.DTOs;

namespace API.Data
{
    public class ThreadsRepository : IThreadsRepo
    {
        private readonly ApplicationDbContext _context;

        public ThreadsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateThread(Thread th)
        {
            _context.Threads.Add(th);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteThread(Thread th)
        {
            _context.Threads.Remove(th);
            await _context.SaveChangesAsync();
        }

        public async Task<Thread> GetThreadById(int id)
        {
            return await _context.Threads.Include(t=> t.Comments).FirstOrDefaultAsync(t=> t.Id == id);
        }

        public async Task<IEnumerable<Thread>> GetThreadsByUserID(string id)
        {
            return await _context.Threads.Where(t => t.UserId.Equals(id)).OrderByDescending(t=> t.Date).ToListAsync();
        }

        public async Task<PaginatedList<Thread>> GetThreads(FilterModel filter)
        {
            var threads = from t in _context.Threads
                          where EF.Functions.Like(t.MovieName, $"%{filter.MovieName ?? ""}%")
                          select t;

            if (!String.IsNullOrEmpty(filter.Category))
                threads = threads.Where(t => t.CategoryFK.Equals(filter.Category));

            return await PaginatedList<Thread>.CreateAsync(
                threads.OrderByDescending(t => t.Date)
                , filter.Page,filter.Limit);
        }
    }
}
