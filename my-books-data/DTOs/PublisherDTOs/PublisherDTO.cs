using my_books_data.Entities;
using System.Collections.Generic;

namespace my_books_data.DTOs.PublisherDTOs
{
    public class PublisherDTO
    {
        public string Name { get; set; }
    }

    public class PublisherWithBooksDTO
    {
        public string Name { get; set; }
        public IList<string> BookTitles { get; set; }
    }

    public class CreatePublisherDTO
    {
        public string Name { get; set; }
    }
    
    public class UpdatePublisherDTO
    {
        public string Name { get; set; }
        public IList<int> BookIds { get; set; }
    }
}
