using my_books_data.DTOs.PublisherDTOs;
using my_books_data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_books_data.Extensions.PublisherEx
{
    public static class Extension
    {
        public static PublisherDTO AsDto(this Publisher publisher) => new PublisherDTO { Id = publisher.Id, Name = publisher.Name };
    }
}
