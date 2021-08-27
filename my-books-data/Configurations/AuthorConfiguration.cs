using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using my_books_data.Entities;
using System;

namespace my_books_data.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn().IsRequired();

            builder.Property(a => a.FirstName).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(a => a.LastName).HasColumnType("nvarchar(100)").IsRequired();
        }
    }
}
