using System.Collections.Generic;

namespace my_books_data.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Book_Author> Book_Authors { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
