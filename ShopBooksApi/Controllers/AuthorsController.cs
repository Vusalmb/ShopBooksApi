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
    public class AuthorsController : ControllerBase
    {
        private readonly ShopDbContext _context;
        public AuthorsController(ShopDbContext context)
        {
            _context = context;
        }

        [Route("get/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            Author author = _context.Authors.FirstOrDefault(b => b.Id == id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Authors.ToList());
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();

            return Ok(author);
        }

        [Route("update")]
        [HttpPut]
        public IActionResult Update(Author author)
        {
            Author existAuthor = _context.Authors.FirstOrDefault(b => b.Id == author.Id);

            if (existAuthor == null)
            {
                return NotFound();
            }

            existAuthor.Name = author.Name;

            _context.SaveChanges();
            return Ok();
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Author author = _context.Authors.FirstOrDefault(b => b.Id == id);

            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            _context.SaveChanges();

            return Ok();
        }
    }
}
