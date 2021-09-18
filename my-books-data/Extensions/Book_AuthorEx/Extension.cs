using my_books_data.DTOs.Book_AuthorDTOs;
using my_books_data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_books_data.Extensions.Book_AuthorEx
{
    public static class Extension
    {
        public static Book_AuthorDTO AsDto(this Book_Author book_Author) => new Book_AuthorDTO
        {
            Id = book_Author.Id,
            BookId = book_Author.Id,
            AuthorId = book_Author.AuthorId
        };
    }
}
