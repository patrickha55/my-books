using Microsoft.AspNetCore.Mvc;
using my_books_application.Services.AuthorServices;
using my_books_data.DTOs.AuthorDTOs;
using my_books_data.Extensions.AuthorEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService authorService;

        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        // GET: api/<AuthorsController>
        [HttpGet]
        public async Task<IEnumerable<AuthorDTO>> Get()
        {
            return await authorService.GetAuthors();
        }

        // GET: api/<AuthorsController>/author-with-books
        [HttpGet("authors-with-books")]
        public async Task<IEnumerable<AuthorWithBooksDTO>> GetAuthorsWithBooks()
        {
            return await authorService.GetAuthorsWithBooks();
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> Get(int id)
        {
            var author = await authorService.GetAuthor(id);

            if (author is null) return NotFound();

            return Ok(author);
        }

        // GET api/<AuthorsController>/author-with-books/5
        [HttpGet("author-with-books/{id}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthorWithBooks(int id)
        {
            var author = await authorService.GetAuthorWithBooks(id);

            if (author is null) return NotFound();

            return Ok(author);
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateAuthorDTO author)
        {
            var createdAuthor = await authorService.CreateAuthor(author);

            return CreatedAtAction(nameof(Post), createdAuthor);
        }

        // POST api/<AuthorsController>/create-author-with-books
        [HttpPost("create-author-with-books")]
        public async Task<ActionResult<AuthorDTO>> Post([FromBody] CreateAuthorWithBooksDTO author)
        {
            await authorService.CreateAuthorWithBooks(author);

            return Ok();
        }

        // PUT api/<AuthorsController>/
        [HttpPut("update-author")]
        public async Task<ActionResult> Put([FromBody] UpdateAuthorDTO author)
        {
            try
            {
                var updatedAuthor = await authorService.UpdateAuthor(author);

                return CreatedAtAction(nameof(Put), updatedAuthor);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AuthorsController>/
        [HttpPut("update-author-with-books")]
        public async Task<ActionResult<AuthorDTO>> Put([FromBody] UpdateAuthorWithBooksDTO author)
        {
            try
            {
                var _author = await authorService.UpdateAuthorWithBooks(author);

                return CreatedAtAction(nameof(Put), _author.AsAuthorDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await authorService.DeleteAuthorAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
