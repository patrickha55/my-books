using my_books_data.DTOs.PublisherDTOs;
using my_books_data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_books_application.Services.PublisherServices
{
    public interface IPublisherService
    {
        Task<IEnumerable<Publisher>> GetPublishersAsync();
        Task<IEnumerable<PublisherWithBooksDTO>> GetPublishersWithBooksAsync();
        Task<Publisher> GetPublisherAsync(int id);
        Task<PublisherWithBooksDTO> GetPublisherWithBooksAsync(int id);
        Task CreateAsync(Publisher publisher);
        Task UpdateAsync(Publisher publisher);
        Task DeleteAsync(Publisher publisher);
    }
}
