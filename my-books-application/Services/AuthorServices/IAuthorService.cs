using my_books_data.DTOs.AuthorDTOs;
using my_books_data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace my_books_application.Services.AuthorServices
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDTO>> GetAuthors();
        Task<IEnumerable<AuthorWithBooksDTO>> GetAuthorsWithBooks();
        Task<AuthorDTO> GetAuthor(int id);
        Task<AuthorWithBooksDTO> GetAuthorWithBooks(int id);
        Task<Author> CreateAuthor(CreateAuthorDTO author);
        Task<Author> CreateAuthorWithBooks(CreateAuthorWithBooksDTO author);
        Task<Author> UpdateAuthor(UpdateAuthorDTO author);
        Task<Author> UpdateAuthorWithBooks(UpdateAuthorWithBooksDTO author);
        Task DeleteAuthorAsync(int id);
    }
}
