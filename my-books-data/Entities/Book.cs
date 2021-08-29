using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace my_books_data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public bool? IsRead { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<Book_Author> Book_Authors { get; set; }
    }
}
