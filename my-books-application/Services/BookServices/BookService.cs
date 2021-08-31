using Microsoft.EntityFrameworkCore;
using my_books_data;
using my_books_data.DTOs.BookDTOs;
using my_books_data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_books_application.Services.BookServices
{
    public class BookService : IBookService
    {
        private readonly ApplicationContext applicationContext;

        public BookService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return await applicationContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await applicationContext.Books.ToListAsync();
        }

        public async Task<IEnumerable<BookWithAditionalInfos>> GetBooksWithAditionalInfosAsync()
        {
            return await applicationContext.Books
                .Select(b => new BookWithAditionalInfos 
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    IsRead = b.IsRead,
                    DateRead = b.DateRead,
                    Rate = b.Rate,
                    Genre = b.Genre,
                    CoverUrl = b.CoverUrl,
                    PublisherName = b.Publisher.Name,
                    AuthorNames = b.Book_Authors.Select(ba => ba.Author.FullName).ToList()
                })  
                .ToListAsync();
        }

        public async Task<BookWithAditionalInfos> GetBookWithAditionalInfosAsync(int id)
        {
            return await applicationContext.Books
                .Where(b => b.Id == id)
                .Select(b => new BookWithAditionalInfos
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    IsRead = b.IsRead,
                    DateRead = b.DateRead,
                    Rate = b.Rate,
                    Genre = b.Genre,
                    CoverUrl = b.CoverUrl,
                    PublisherName = b.Publisher.Name,
                    AuthorNames = b.Book_Authors.Select(ba => ba.Author.FullName).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Book book)
        {
            await applicationContext.Books.AddAsync(book);
            await applicationContext.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Book book)
        {
            applicationContext.Books.Update(book);
            await applicationContext.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Book book)
        {
            applicationContext.Books.Remove(book);
            await applicationContext.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}
