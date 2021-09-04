using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_books_data.DTOs.Book_AuthorDTOs
{
    public class Book_AuthorDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
    }

    public class CreateBook_AuthorDTO
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
    }
}
