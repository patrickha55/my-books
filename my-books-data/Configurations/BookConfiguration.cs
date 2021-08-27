using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using my_books_data.Entities;
using System;

namespace my_books_data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).UseIdentityColumn().IsRequired();

            builder.Property(b => b.Title).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(b => b.Description).IsRequired();
            builder.Property(b => b.Rate).HasDefaultValue(0);
            builder.Property(b => b.Genre).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(b => b.CoverUrl).HasColumnType("nvarchar").IsRequired();
            builder.Property(b => b.DateAdded).HasColumnType("Date").HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(b => b.DateRead).HasColumnType("Date");

            builder.HasOne(b => b.Publisher).WithMany(p => p.Books).HasForeignKey(b => b.PublisherId);
        }
    }
}
