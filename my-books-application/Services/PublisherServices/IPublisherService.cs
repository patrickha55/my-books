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
        Task<IEnumerable<PublisherDTO>> GetPublishersAsync();
        Task<IEnumerable<PublisherWithBooksDTO>> GetPublishersWithBooksAsync();
        Task<PublisherDTO> GetPublisherAsync(int id);
        Task<PublisherWithBooksDTO> GetPublisherWithBooksAsync(int id);
        Task<Publisher> CreateAsync(CreatePublisherDTO publisherDTO);
        Task<Publisher> UpdateAsync(UpdatePublisherDTO publisherDTO);
        Task DeleteAsync(int id);
    }
}
