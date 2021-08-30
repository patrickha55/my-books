using Microsoft.EntityFrameworkCore;
using my_books_data;
using my_books_data.DTOs.PublisherDTOs;
using my_books_data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_books_application.Services.PublisherServices
{
    public class PublisherService : IPublisherService
    {
        private readonly ApplicationContext applicationContext;

        public PublisherService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<Publisher> GetPublisherAsync(int id)
        {
            return await applicationContext.Publishers.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Publisher>> GetPublishersAsync()
        {
            return await applicationContext.Publishers.ToListAsync();
        }

        public async Task<IEnumerable<PublisherWithBooksDTO>> GetPublishersWithBooksAsync()
        {
            return await applicationContext.Publishers.Select(p => new PublisherWithBooksDTO
            {
                Id = p.Id,
                Name = p.Name,
                BookTitles = p.Books.Select(b => b.Title).ToList()
            })
            .ToListAsync();
        }

        public async Task<PublisherWithBooksDTO> GetPublisherWithBooksAsync(int id)
        {
            var publisher = applicationContext.Publishers
                .Where(p => p.Id == id)
                .Select(p => new PublisherWithBooksDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    BookTitles = p.Books.Select(b => b.Title).ToList()
                });

            return await publisher.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Publisher publisher)
        {
            await applicationContext.Publishers.AddAsync(publisher);
            await applicationContext.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Publisher publisher)
        {
            applicationContext.Publishers.Update(publisher);
            await applicationContext.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Publisher publisher)
        {
            applicationContext.Publishers.Remove(publisher);
            await applicationContext.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}
