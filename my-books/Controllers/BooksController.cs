using Microsoft.AspNetCore.Mvc;
using my_books_application.Services.Book_AuthorServices;
using my_books_application.Services.BookServices;
using my_books_data.DTOs.BookDTOs;
using my_books_data.Entities;
using my_books_data.Extensions.BookEx;
using my_books_data.Extensions.PublisherEx;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IBook_AuthorService book_AuthorService;

        public BooksController(IBookService bookService, IBook_AuthorService book_AuthorService)
        {
            this.bookService = bookService;
            this.book_AuthorService = book_AuthorService;
        }

        // GET: api/<PublishersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> Get()
        {
            var bookDto = (await bookService.GetBooksAsync()).Select(b => b.AsDto()).ToList();
            return Ok(bookDto);
        }

        // GET: api/<PublishersController>/publisher-with-books
        [HttpGet("publisher-with-books")]
        public async Task<ActionResult<IEnumerable<BookWithAditionalInfos>>> GetPublishersWithBooks() 
        {
            return Ok(await bookService.GetBooksWithAditionalInfosAsync());
        }

        // GET api/<PublishersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> Get(int id)
        {
            var book = await bookService.GetBookAsync(id);

            if (book is null) return NotFound();

            return Ok(book.AsDto());
        }

        // GET api/<PublishersController>/publisher-with-books/5
        [HttpGet("publisher-with-books/{id}")]
        public async Task<ActionResult<BookWithAditionalInfos>> GetPublisherWithBooksAsync(int id)
        {
            var bookWithAditionalInfos = await bookService.GetBookWithAditionalInfosAsync(id);

            if (bookWithAditionalInfos is null) return NotFound();

            return Ok(bookWithAditionalInfos);
        }

        // POST api/<PublishersController>
        [HttpPost]
        public async Task<ActionResult<BookDTO>> Post([FromBody] CreateBookDTO bookDto)
        {
            Book book = new Book
            {
                Title = bookDto.Title,
                Description = bookDto.Description,
                IsRead = bookDto.IsRead,
                DateRead = bookDto.DateRead,
                Rate = bookDto.Rate,
                Genre = bookDto.Genre,
                CoverUrl = bookDto.CoverUrl,
                PublisherId = bookDto.PublisherId
            };

            await bookService.CreateAsync(book);

            foreach (var id in bookDto.AuthorIds)
            {
                Book_Author ba = new Book_Author() { BookId = book.Id, AuthorId = id };

                await book_AuthorService.CreateAsync(ba);
            }

            return CreatedAtAction(nameof(Get), new { Id = book.Id }, book.AsDto());
        }

        // PUT api/<PublishersController>/5
        [HttpPut]
        public async Task<ActionResult<BookDTO>> Put([FromBody] UpdateBookDTO bookDto)
        {
            var book = await bookService.GetBookAsync(bookDto.Id);

            if (book is null) return NotFound();

            book.Title = bookDto.Title;
            book.Description = bookDto.Description;
            book.IsRead = bookDto.IsRead;
            book.DateRead = bookDto.DateRead;
            book.Rate = bookDto.Rate;
            book.Genre = bookDto.Genre;
            book.CoverUrl = bookDto.CoverUrl;
            book.PublisherId = bookDto.PublisherId;

            await bookService.UpdateAsync(book);

            var book_authors = await book_AuthorService.GetByBookOrAuthorIdAsync(bookId: book.Id, authorId: null);
            
            if(book_authors is not null)
            {
                foreach (var ba in book_authors)
                {
                    await book_AuthorService.DeleteAsync(ba);
                }
            }

            foreach (var id in bookDto.AuthorIds)
            {
                Book_Author book_Author = new Book_Author() { AuthorId = id, BookId = book.Id };

                await book_AuthorService.CreateAsync(book_Author);
            }

            return CreatedAtAction(nameof(Get), new { Id = book.Id }, book.AsDto());
        }

        // DELETE api/<PublishersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var book = await bookService.GetBookAsync(id);

            if (book is null) return NotFound();

            await bookService.DeleteAsync(book);

            return Redirect(nameof(Get));
        }
    }
}
