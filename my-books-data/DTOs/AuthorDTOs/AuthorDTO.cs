using System.Collections.Generic;

namespace my_books_data.DTOs.AuthorDTOs
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }

    public class AuthorWithBooksDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public IList<string> BookTitles { get; set; }
    }

    public class CreateAuthorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CreateAuthorWithBooksDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<int> BookIds { get; set; }
    }

    public class UpdateAuthorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class UpdateAuthorWithBooksDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<int> BookIds { get; set; }
    }
}
