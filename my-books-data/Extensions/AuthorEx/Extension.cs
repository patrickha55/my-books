using my_books_data.DTOs.AuthorDTOs;
using my_books_data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_books_data.Extensions.AuthorEx
{
    public static class Extension
    {
        public static AuthorDTO AsAuthorDto(this Author author) => new AuthorDTO() { FirstName = author.FirstName, LastName = author.LastName };

        /*public static AuthorWithBooksDTO AsAuthorWithBooksDto(this Author author) => new AuthorWithBooksDTO()
        {
            FirstName = author.FirstName,
            LastName = author.LastName,
            BookTitles = author.Book_Authors.Select(ba => ba.Book.Title).ToList()
        };*/
    }
}
