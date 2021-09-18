using my_books_data.DTOs.BookDTOs;
using my_books_data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_books_application.Services.BookServices
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<IEnumerable<BookWithAditionalInfos>> GetBooksWithAditionalInfosAsync();
        Task<Book> GetBookAsync(int id);
        Task<BookWithAditionalInfos> GetBookWithAditionalInfosAsync(int id);
        Task CreateAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
    }
}
