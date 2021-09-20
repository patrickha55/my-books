using my_books_data.DTOs.AuthorDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myBooksBlazorWASAP.Services.AuthorServices
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDTO>> GetAuthors();
    }
}