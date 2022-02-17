using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopBooksApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.DAL.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(n => n.Name).HasMaxLength(150).IsRequired(true);
            builder.Property(i => i.Image).HasMaxLength(150);
            builder.Property(d => d.Detail).HasMaxLength(500).IsRequired(true);
            builder.Property(l => l.Language).HasMaxLength(50).IsRequired(true);
            builder.Property(p => p.Price).IsRequired(true);
            builder.Property(p => p.Publishing).HasMaxLength(50).IsRequired(true);
            builder.Property(p => p.Cover).HasMaxLength(50).IsRequired(true);
            builder.Property(p => p.Weight).HasMaxLength(50).IsRequired(true);
            builder.Property(p => p.PageCount).IsRequired(true);
            builder.Property(p => p.IsDelete).HasDefaultValue(false);
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(p => p.ModifiedAt).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
