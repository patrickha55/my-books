using Microsoft.EntityFrameworkCore;
using my_books_data;
using my_books_data.DTOs.AuthorDTOs;
using my_books_data.Entities;
using my_books_data.Extensions.AuthorEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_application.Services.AuthorServices
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationContext applicationContext;

        public AuthorService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<Author> CreateAuthor(CreateAuthorDTO author)
        { 
            Author _author = new()
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            await applicationContext.Authors.AddAsync(_author);
            await applicationContext.SaveChangesAsync();

            return _author;
        }

        public async Task<Author> CreateAuthorWithBooks(CreateAuthorWithBooksDTO author)
        {
            if (author is not null)
            {
                Author _author = new()
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName
                };

                await applicationContext.Authors.AddAsync(_author);
                await applicationContext.SaveChangesAsync();

                foreach (var id in author.BookIds)
                {
                    Book_Author book_Author = new()
                    {
                        AuthorId = _author.Id,
                        BookId = id
                    };

                    await applicationContext.Book_Authors.AddAsync(book_Author);
                    await applicationContext.SaveChangesAsync();
                }

                return await Task.FromResult(_author);
            }
            else
            {
                throw new Exception();
            }
        }


        public async Task<IEnumerable<AuthorDTO>> GetAuthors()
        {
            return await applicationContext.Authors.Select(a => a.AsAuthorDto()).ToListAsync();
        }

        public async Task<IEnumerable<AuthorWithBooksDTO>> GetAuthorsWithBooks()
        {
            var authors = await applicationContext.Authors
                .Select(a => new AuthorWithBooksDTO()
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    BookTitles = a.Book_Authors.Select(ba => ba.Book.Title).ToList()
                })
                .ToListAsync();

            return authors;
        }
        public async Task<AuthorDTO> GetAuthor(int id)
        {
            var author = await applicationContext.Authors.FirstOrDefaultAsync(a => a.Id == id);

            return author.AsAuthorDto();
        }

        public async Task<AuthorWithBooksDTO> GetAuthorWithBooks(int id)
        {
            var author = applicationContext.Authors.Where(a => a.Id == id).Select(a => new AuthorWithBooksDTO()
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                BookTitles = a.Book_Authors.Select(ba => ba.Book.Title).ToList()
            });

            return await author.FirstOrDefaultAsync();
        }

        public async Task<Author> UpdateAuthor(UpdateAuthorDTO author)
        {
            var _author = await applicationContext.Authors.FirstOrDefaultAsync(a => a.Id == author.Id);

            if (_author is null)
            {
                throw new KeyNotFoundException($"Author with id {author.Id} doest not exist.");
            }
            else
            {
                _author.FirstName = author.FirstName;
                _author.LastName = author.LastName;

                applicationContext.Authors.Update(_author);
                await applicationContext.SaveChangesAsync();

                return _author;
            }
        }

        public async Task<Author> UpdateAuthorWithBooks(UpdateAuthorWithBooksDTO author)
        {
            var _author = await applicationContext.Authors.FirstOrDefaultAsync(a => a.Id == author.Id);

            if (_author is null)
            {
                throw new KeyNotFoundException($"Author with id {author.Id} doest not exist.");
            }
            else
            {
                _author.FirstName = author.FirstName;
                _author.LastName = author.LastName;

                var book_author = applicationContext.Book_Authors.Where(ba => ba.AuthorId == _author.Id);

                if (book_author is not null)
                {
                    applicationContext.Book_Authors.RemoveRange(book_author);
                }

                foreach (var id in author.BookIds)
                {
                    Book_Author ba = new()
                    {
                        BookId = id,
                        AuthorId = _author.Id
                    };

                    await applicationContext.Book_Authors.AddAsync(ba);
                    await applicationContext.SaveChangesAsync();
                }

                applicationContext.Authors.Update(_author);
                await applicationContext.SaveChangesAsync();

                return await Task.FromResult(_author);
            }
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var author = await applicationContext.Authors.FirstOrDefaultAsync(a => a.Id == id);

            if (author is not null)
            {
                applicationContext.Authors.Remove(author);
                await applicationContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"The author with id {id} does not exist.");
            }

            await Task.CompletedTask;
        }
    }
}
