using my_books_data.Entities;
using System.Collections.Generic;

namespace my_books_data.DTOs.PublisherDTOs
{
    public class PublisherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PublisherWithBooksDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<string> BookTitles { get; set; }
    }

    public class CreatePublisherDTO
    {
        public string Name { get; set; }
    }
    
    public class UpdatePublisherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
