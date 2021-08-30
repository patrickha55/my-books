using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace my_books_data.DTOs.BookDTOs
{
    public class BookDTO
    { 
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public bool IsRead { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        public string PublisherName { get; set; }
    }

    public class BookWithAditionalInfos
    {
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public bool IsRead { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        public string PublisherName { get; set; }
        public IList<string> AuthorNames { get; set; }
    }

    public class CreateBookDTO
    {
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public bool IsRead { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        public int PublisherId { get; set; }
        public IList<int> AuthorIds { get; set; }
    }

    public class UpdateBookDTO
    {
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public bool IsRead { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        public int PublisherId { get; set; }
        public IList<int> AuthorIds { get; set; }
    }
}
