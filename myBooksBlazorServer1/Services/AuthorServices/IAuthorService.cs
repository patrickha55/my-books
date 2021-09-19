using my_books_data.DTOs.AuthorDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myBooksBlazorServer1.Services.AuthorServices
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDTO>> GetAuthorsAsync();
        Task<AuthorDTO> GetAuthorAsync(int id);
        Task CreateAsync(CreateAuthorDTO author);
        Task UpdateAsync(UpdateAuthorDTO author);
        Task DeleteAsync(int id);
    }
}