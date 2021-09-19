using my_books_data.DTOs.AuthorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace myBooksBlazorServer1.Services.AuthorServices
{
    public class AuthorService : IAuthorService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly JsonSerializerOptions options;
        private readonly string uri = "http://localhost:15203/api/authors/";

        public AuthorService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<AuthorDTO> GetAuthorAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri + $"{id}");
            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<AuthorDTO>(reponseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<AuthorDTO>> GetAuthorsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<AuthorDTO>>(reponseStream, options);
            }
            else
            {
                return null;
            }
        }
        public async Task CreateAsync(CreateAuthorDTO author)
        {
            if (author is not null)
            {
                var client = clientFactory.CreateClient();
                var authorJson = new StringContent(
                    JsonSerializer.Serialize(author, options),
                    encoding: Encoding.UTF8,
                    "application/json"
                    );

                using var httpResponse = await client.PostAsync(uri, authorJson);

                httpResponse.EnsureSuccessStatusCode();
            }
        }

        public async Task UpdateAsync(UpdateAuthorDTO author)
        {
            if (author is not null)
            {
                var client = clientFactory.CreateClient();
                var authorJson = new StringContent(
                    JsonSerializer.Serialize(author, options),
                    encoding: Encoding.UTF8,
                    "application/json"
                    );

                using var httpResponse = await client.PutAsync(uri + "update-author/", authorJson);

                httpResponse.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteAsync(int id)
        {
            if (id != 0)
            {
                var client = clientFactory.CreateClient();
                using var httpResponse = await client.DeleteAsync(uri + $"{id}");

                httpResponse.EnsureSuccessStatusCode();
            }
        }
    }
}
