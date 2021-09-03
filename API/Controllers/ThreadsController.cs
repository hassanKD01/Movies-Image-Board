using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;
using API.DTOs;
using AutoMapper;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/threads")]
    [ApiController]
    public class ThreadsController : ControllerBase
    {
        private readonly IThreadsRepo _repository;
        private readonly IMapper _mapper;

        public ThreadsController(IThreadsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/threads
        [HttpGet]
        public async Task<ActionResult> GetThread([FromQuery] FilterModel filter)
        {
            PaginatedList<Thread> threads = await _repository.GetThreads(filter);
            PaginatedList<ThreadsListDTO> threadsList =_mapper.Map<PaginatedList<ThreadsListDTO>>(threads);
            var metadata = new
            {
                threads.PageIndex,
                threads.TotalPages
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(threadsList);
        }

        // GET api/threads/5
        [HttpGet("thread/{id}")]
        public async Task< ActionResult<ThreadReadDTO>> GetThreadByID(int id)
        {
            var thread = await _repository.GetThreadById(id);
            if (thread != null)
            {
                return Ok(_mapper.Map<ThreadReadDTO>(thread));
            }
            return NotFound();
        }

        [HttpGet("userthreads/{userid}")]
        public async Task<ActionResult<IEnumerable<ThreadsListDTO>>> GetUserThreads(string userid)
        {
            return Ok(_mapper.Map<IEnumerable<ThreadsListDTO>>(await _repository.GetThreadsByUserID(userid)));
        }

        // POST api/threads
        [HttpPost]
        public async Task< ActionResult<Thread>> Post([FromBody] ThreadCreateDTO th)
        {
            if (th == null)
            {
                throw new ArgumentNullException(nameof(th));
            }
            Thread thread = _mapper.Map<Thread>(th);
            await _repository.CreateThread(thread);
            return CreatedAtAction(nameof(Post), thread);
        }


        // DELETE api/threads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Thread th =await _repository.GetThreadById(id);
            if (th == null)
            {
                return NotFound();
            }
            await _repository.DeleteThread(th);
            return NoContent();
        }
    }
}
