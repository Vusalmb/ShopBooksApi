using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopBooksApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.DAL.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(n => n.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(i => i.Image).HasMaxLength(150);
            builder.Property(p => p.IsDelete).HasDefaultValue(false);
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(p => p.ModifiedAt).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
