using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class GenresController : ControllerBase
    {
        private readonly ShopDbContext _context;
        public GenresController(ShopDbContext context)
        {
            _context = context;
        }

        [Route("get/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            Book genre = _context.Genres.FirstOrDefault(b => b.Id == id);

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Genres.ToList());
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(Book genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();

            return Ok(genre);
        }

        [Route("update")]
        [HttpPut]
        public IActionResult Update(Book genre)
        {
            Book existGenre = _context.Genres.FirstOrDefault(b => b.Id == genre.Id);

            if (existGenre == null)
            {
                return NotFound();
            }

            existGenre.Name = genre.Name;

            _context.SaveChanges();
            return Ok();
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Book genre = _context.Genres.FirstOrDefault(b => b.Id == id);

            if (genre == null)
            {
                return NotFound();
            }

            _context.Genres.Remove(genre);
            _context.SaveChanges();

            return Ok();
        }
    }
}
