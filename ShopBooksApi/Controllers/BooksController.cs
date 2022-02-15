using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBooksApi.DAL.Data;
using ShopBooksApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ShopDbContext _context;
        public BooksController(ShopDbContext context)
        {
            _context = context;
        }

        [Route("get/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            Book book = _context.Books.FirstOrDefault(b => b.Id == id);

            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Books.ToList());
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return Ok(book);
        }

        [Route("update")]
        [HttpPut]
        public IActionResult Update(Book book)
        {
            Book existBook = _context.Books.Include(b=>b.Author).Include(b => b.Genre).FirstOrDefault(b => b.Id == book.Id);

            if(!_context.Genres.Any(g=>g.Id == book.GenreId))
            {
                return NotFound();
            }

            if (!_context.Authors.Any(a => a.Id == book.AuthorId))
            {
                return NotFound();
            }

            if (existBook == null)
            {
                return NotFound();
            }

            existBook.Name = book.Name;
            existBook.Detail = book.Detail;
            existBook.Language = book.Language;
            existBook.GenreId = book.GenreId;
            existBook.AuthorId = book.AuthorId;
            existBook.Date = book.Date;
            existBook.Price = book.Price;

            _context.SaveChanges();
            return Ok();
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Book book = _context.Books.FirstOrDefault(b => b.Id == id);

            if(book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();

            return Ok();
        }
    }
}
