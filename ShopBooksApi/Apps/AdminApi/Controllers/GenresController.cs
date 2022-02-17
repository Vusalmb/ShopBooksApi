using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBooksApi.Apps.AdminApi.DTOs.GenreDTOs;
using ShopBooksApi.DAL.Data;
using ShopBooksApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBooksApi.Controllers
{
    [Route("admin/api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ShopDbContext _context;
        private readonly IWebHostEnvironment _env;
        public GenresController(ShopDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [Route("get/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            Genre genre = _context.Genres.FirstOrDefault(b => b.Id == id & !b.IsDelete);

            if (genre == null)
            {
                return NotFound();
            }

            GenreGetDTO genreGet = new GenreGetDTO
            {
                Id = genre.Id,
                Name = genre.Name,
                DisplayStatus = genre.DisplayStatus,
                CreatedAt = genre.CreatedAt,
                ModifiedAt = genre.ModifiedAt
            };

            return Ok(genreGet);
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAll(string search=null)
        {
            var query = _context.Genres.Where(g => !g.IsDelete);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(g => g.Name.Contains(search));
            }

            GenreListDTO genreList = new GenreListDTO
            {
                Items = query.Select(g=>new GenreListItemDTO
                {
                    Id = g.Id,
                    Name = g.Name,
                    DisplayStatus = g.DisplayStatus
                }).ToList(),
                TotalCount = query.Count()
            };

            return Ok(genreList);
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(GenrePostDTO genrePost)
        {
            Genre genre = new Genre
            {
                Name = genrePost.Name,
                DisplayStatus = genrePost.DisplayStatus
            };

            _context.Genres.Add(genre);
            _context.SaveChanges();

            return Ok(genre);
        }

        [Route("update/{id}")]
        [HttpPut]
        public IActionResult Update(int id, GenrePutDTO genrePut)
        {
            Genre existGenre = _context.Genres.FirstOrDefault(b => b.Id == id);

            if (existGenre == null)
            {
                return NotFound();
            }

            existGenre.Name = genrePut.Name;
            existGenre.DisplayStatus = genrePut.DisplayStatus;

            _context.SaveChanges();
            return Ok();
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Genre genre = _context.Genres.FirstOrDefault(b => b.Id == id && !b.IsDelete);

            if (genre == null)
            {
                return NotFound();
            }

            genre.IsDelete = true;
            genre.ModifiedAt = DateTime.UtcNow;
            _context.SaveChanges();

            return Ok();
        }

        [Route("{id}")]
        [HttpPatch]
        public IActionResult ChangeStatus(int id, bool status)
        {
            Genre genre = _context.Genres.FirstOrDefault(g => g.Id == id);

            if (genre == null)
            {
                return NotFound();
            }

            genre.DisplayStatus = status;
            _context.SaveChanges();

            return Ok();
        }
    }
}
