using Microsoft.EntityFrameworkCore;
using my_books_application.Exceptions;
using my_books_data;
using my_books_data.DTOs.PublisherDTOs;
using my_books_data.Entities;
using my_books_data.Extensions.PublisherEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public async Task<PublisherDTO> GetPublisherAsync(int id)
        {
            return (await applicationContext.Publishers.FirstOrDefaultAsync(p => p.Id == id)).AsDto();
        }

        public async Task<IEnumerable<PublisherDTO>> GetPublishersAsync()
        {
            var publishers = applicationContext.Publishers.Select(p => p.AsDto());
            return await publishers.ToListAsync();
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

        public async Task<Publisher> CreateAsync(CreatePublisherDTO publisherDTO)
        {
            if (StringStartsWithNumber(publisherDTO.Name)) throw new PublisherNameException("Name starts with number", publisherDTO.Name);

            Publisher publisher = new() { Name = publisherDTO.Name };

            await applicationContext.Publishers.AddAsync(publisher);
            await applicationContext.SaveChangesAsync();

            return await Task.FromResult(publisher);
        }

        public async Task<Publisher> UpdateAsync(UpdatePublisherDTO publisherDTO)
        {
            var publisher = await applicationContext.Publishers.FirstOrDefaultAsync(p => p.Id == publisherDTO.Id);

            if (publisher is null) throw new KeyNotFoundException($"Publisher with id {publisherDTO.Id} does not exist.");

            publisher.Name = publisherDTO.Name;

            applicationContext.Publishers.Update(publisher);
            await applicationContext.SaveChangesAsync();

            return await Task.FromResult(publisher);
        }

        public async Task DeleteAsync(int id)
        {
            var publisher = await applicationContext.Publishers.FirstOrDefaultAsync(p => p.Id == id);

            if (publisher is null) throw new KeyNotFoundException($"Publisher with id {id} does not exist.");

            applicationContext.Publishers.Remove(publisher);
            await applicationContext.SaveChangesAsync();

            await Task.CompletedTask;
        }

        private bool StringStartsWithNumber(string name) => Regex.IsMatch(name, @"^\d");
    }
}
