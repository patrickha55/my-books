using Microsoft.EntityFrameworkCore;
using my_books_data;
using my_books_data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_books_application.Services.Book_AuthorServices
{
    public class Book_AuthorService : IBook_AuthorService
    {
        private readonly ApplicationContext applicationContext;

        public Book_AuthorService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task CreateAsync(Book_Author book_Author)
        {
            await applicationContext.Book_Authors.AddAsync(book_Author);
            await applicationContext.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Book_Author book_Author)
        {
            applicationContext.Book_Authors.Remove(book_Author);
            await applicationContext.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Book_Author>> GetAsync()
        {
            return await applicationContext.Book_Authors.ToListAsync();
        }

        public async Task<Book_Author> GetAsync(int id)
        {
            return await applicationContext.Book_Authors.FirstOrDefaultAsync(ba => ba.Id == id);
        }

        public async Task<IEnumerable<Book_Author>> GetByBookOrAuthorIdAsync(int? bookId, int? authorId)
        {
            var book_authors = applicationContext.Book_Authors.Where(ba => ba.BookId == bookId && ba.AuthorId == authorId);

            return await book_authors.ToListAsync();
        }

        public async Task UpdateAsync(Book_Author book_Author)
        {
            applicationContext.Book_Authors.Update(book_Author);
            await applicationContext.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}
