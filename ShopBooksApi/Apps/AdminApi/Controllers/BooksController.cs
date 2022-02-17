using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBooksApi.Apps.AdminApi.DTOs.BookDTOs;
using ShopBooksApi.DAL.Data;
using ShopBooksApi.DAL.Entities;
using ShopBooksApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Controllers
{

    [Route("admin/api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ShopDbContext _context;
        private readonly IWebHostEnvironment _env;
        public BooksController(ShopDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [Route("get/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            Book book = _context.Books.Include(b=>b.Author).Include(b=>b.Genre).ThenInclude(b => b.Books).FirstOrDefault(b => b.Id == id & !b.IsDelete);

            if(book == null)
            {
                return NotFound();
            }

            BookGetDTO bookGet = new BookGetDTO
            {
                Id = book.Id,
                Name = book.Name,
                Image = book.Image,
                Detail = book.Detail,
                Language = book.Language,
                Publishing = book.Publishing,
                Cover = book.Cover,
                Weight = book.Weight,
                DisplayStatus = book.DisplayStatus,
                PageCount = book.PageCount,
                Price = book.Price,
                CreatedAt = book.CreatedAt,
                ModifiedAt = book.ModifiedAt,
                Author = new AuthorInBookGetDTO
                {
                    Id = book.AuthorId,
                    Name = book.Author.Name,
                    BookCounts = book.Author.Books.Count
                },
                Genre = new GenreInBookGetDTO
                {
                    Id = book.GenreId,
                    Name = book.Genre.Name,
                    BookCounts = book.Genre.Books.Count
                }
            };

            return Ok(bookGet);
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAll(int page=1, string search=null)
        {
            var query = _context.Books.Include(b => b.Author).Include(b => b.Genre).Where(b=>!b.IsDelete);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(b => b.Name.Contains(search));
            }

            BookListDTO bookList = new BookListDTO
            {
                Items = query.Skip((page - 1) * 8).Take(8).Select(b => new BookListItemDTO {
                    Id = b.Id,
                    Name = b.Name,
                    Image = b.Image,
                    Detail = b.Detail,
                    Language = b.Language,
                    Publishing = b.Publishing,
                    Cover = b.Cover,
                    Weight = b.Weight,
                    DisplayStatus = b.DisplayStatus,
                    PageCount = b.PageCount,
                    Date = b.Date,
                    Price = b.Price,
                    Author = new AuthorInBookListItemDTO
                    {
                        Id = b.AuthorId,
                        Name = b.Author.Name
                    },
                    Genre = new GenreInBookListItemDTO
                    {
                        Id = b.GenreId,
                        Name = b.Genre.Name
                    }
                }).ToList(),
                TotalCount = query.Count()
            };

            return Ok(bookList);
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromForm] BookPostDTO bookPost)
        {
            if (!_context.Genres.Any(g => g.Id == bookPost.GenreId && !g.IsDelete))
            {
                return NotFound();
            }

            if (!_context.Authors.Any(a => a.Id == bookPost.AuthorId && !a.IsDelete))
            {
                return NotFound();
            }

            Book book = new Book
            {
                Name = bookPost.Name,
                Detail = bookPost.Detail,
                Language = bookPost.Language,
                PageCount = bookPost.PageCount,
                AuthorId = bookPost.AuthorId,
                GenreId = bookPost.GenreId,
                Date = bookPost.Date,
                Price = bookPost.Price,
                Publishing = bookPost.Publishing,
                Cover = bookPost.Cover,
                Weight = bookPost.Weight
            };

            book.Image = bookPost.Image.SaveImg(_env.WebRootPath, "assets/image");

            _context.Books.Add(book);
            _context.SaveChanges();

            return Ok(book);
        }

        [Route("update/{id}")]
        [HttpPut]
        public IActionResult Update(int id, BookPutDTO bookPut)
        {
            Book existBook = _context.Books.Include(b=>b.Author).Include(b => b.Genre).FirstOrDefault(b => b.Id == id);

            if (existBook == null)
            {
                return NotFound();
            }

            if (!_context.Genres.Any(g=>g.Id == bookPut.GenreId))
            {
                return NotFound();
            }

            if (!_context.Authors.Any(a => a.Id == bookPut.AuthorId))
            {
                return NotFound();
            }

            existBook.Name = bookPut.Name;
            existBook.Image = bookPut.Image;
            existBook.Detail = bookPut.Detail;
            existBook.Language = bookPut.Language;
            existBook.GenreId = bookPut.GenreId;
            existBook.AuthorId = bookPut.AuthorId;
            existBook.Price = bookPut.Price;
            existBook.PageCount = bookPut.PageCount;
            existBook.Publishing = bookPut.Publishing;
            existBook.Cover = bookPut.Cover;
            existBook.Weight = bookPut.Weight;

            _context.SaveChanges();
            return Ok();
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Book book = _context.Books.FirstOrDefault(b => b.Id == id && !b.IsDelete);

            if(book == null)
            {
                return NotFound();
            }

            book.IsDelete = true;
            book.ModifiedAt = DateTime.UtcNow;
            _context.SaveChanges();

            return Ok();
        }

        [Route("{id}")]
        [HttpPatch]
        public IActionResult ChangeStatus(int id, bool status)
        {
            Book book = _context.Books.FirstOrDefault(p => p.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            book.DisplayStatus = status;
            _context.SaveChanges();

            return Ok();
        }
    }
}
