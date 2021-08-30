using my_books_data.DTOs.AuthorDTOs;
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
        Task CreateAuthor(CreateAuthorDTO author);
        Task CreateAuthorWithBooks(CreateAuthorWithBooksDTO author);
        Task UpdateAuthor(UpdateAuthorDTO author);
        Task UpdateAuthorWithBooks(UpdateAuthorWithBooksDTO author);
        Task DeleteAuthorAsync(int id);
    }
}
