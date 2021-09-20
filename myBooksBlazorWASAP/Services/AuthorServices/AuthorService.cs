using my_books_data.DTOs.AuthorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace myBooksBlazorWASAP.Services.AuthorServices
{
    public class AuthorService : IAuthorService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public AuthorService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<AuthorDTO>> GetAuthors()
        {
            var response = await _client.GetAsync("actors/");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var authors = JsonSerializer.Deserialize<IEnumerable<AuthorDTO>>(content, _options);

            return authors;
        }
    }
}
