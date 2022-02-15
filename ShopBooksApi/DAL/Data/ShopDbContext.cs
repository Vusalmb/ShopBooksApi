using Microsoft.EntityFrameworkCore;
using ShopBooksApi.DAL.Configuration;
using ShopBooksApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.DAL.Data
{
    public class ShopDbContext: DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options):base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
