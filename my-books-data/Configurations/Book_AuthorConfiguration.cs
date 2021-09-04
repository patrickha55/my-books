using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using my_books_data.Entities;
using System;

namespace my_books_data.Configurations
{
    public class Book_AuthorConfiguration : IEntityTypeConfiguration<Book_Author>
    {
        public void Configure(EntityTypeBuilder<Book_Author> builder)
        {
            builder.ToTable("Book_Authors");

            builder.HasKey(ba => ba.Id);
            builder.Property(ba => ba.Id).UseIdentityColumn().IsRequired();

            builder.HasOne(ba => ba.Author).WithMany(a => a.Book_Authors).HasForeignKey(ba => ba.AuthorId);
            builder.HasOne(ba => ba.Book).WithMany(b => b.Book_Authors).HasForeignKey(ba => ba.BookId);
        }
    }
}
