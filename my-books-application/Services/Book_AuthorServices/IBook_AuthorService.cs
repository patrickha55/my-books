using my_books_data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_books_application.Services.Book_AuthorServices
{
    public interface IBook_AuthorService
    {
        Task<IEnumerable<Book_Author>> GetAsync();
        Task<Book_Author> GetAsync(int id);
        Task<IEnumerable<Book_Author>> GetByBookOrAuthorIdAsync(int? bookId, int? authorId);
        Task CreateAsync(Book_Author book_Author);
        Task UpdateAsync(Book_Author book_Author);
        Task DeleteAsync(Book_Author book_Author);
    }
}
