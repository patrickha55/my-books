using my_books_data.DTOs.BookDTOs;
using my_books_data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_books_data.Extensions.BookEx
{
    public static class Extension
    {
        public static BookDTO AsDto(this Book book) => new BookDTO
        {
            Title = book.Title,
            Description = book.Description,
            IsRead = book.IsRead,
            DateRead = book.DateRead,
            Rate = book.Rate,
            Genre = book.Genre,
            CoverUrl = book.CoverUrl,
            PublisherName = book.Publisher.Name
        };
    }
}
