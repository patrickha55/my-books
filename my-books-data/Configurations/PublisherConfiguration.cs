using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using my_books_data.Entities;
using System;

namespace my_books_data.Configurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.ToTable("Publishers");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn().IsRequired();

            builder.Property(p => p.Name).HasColumnType("nvarchar(100)").IsRequired();

            builder.HasMany(p => p.Books).WithOne(b => b.Publisher);
        }
    }
}
