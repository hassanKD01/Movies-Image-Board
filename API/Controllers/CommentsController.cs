using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsRepo _repository;
        private readonly IMapper _mapper;

        public CommentsController(ICommentsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/<CommentsController>
        [HttpGet("{id}")]
        public async Task<ActionResult< IEnumerable<CommentReadDTO>>> Get(int id)
        {
            return Ok(_mapper.Map<IEnumerable<CommentReadDTO>>( await _repository.GetAllComments(id)));
        }

        // POST api/<CommentsController>
        [HttpPost]
        public async Task<ActionResult<Comment>> Post([FromBody] CommentCreateDTO cmnt)
        {
            if (cmnt == null)
            {
                throw new ArgumentNullException(nameof(cmnt));
            }
            Comment comment = _mapper.Map<Comment>(cmnt);
            await _repository.CreateComment(comment);
            return CreatedAtRoute(nameof(_repository.GetCommentByID), new { Id = comment.ThreadId }, comment);
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Comment comment = await _repository.GetCommentByID(id);
            if (comment == null)
            {
                return NotFound();
            }
            await _repository.DeleteComment(comment);
            return NoContent();
        }
    }
}
