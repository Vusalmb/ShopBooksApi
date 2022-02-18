using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBooksApi.Apps.AdminApi.DTOs.AuthorDTOs;
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
    public class AuthorsController : ControllerBase
    {
        private readonly ShopDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public AuthorsController(ShopDbContext context, IWebHostEnvironment env, IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;
        }

        [Route("get/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            Author author = _context.Authors.Include(a=>a.Books).FirstOrDefault(b => b.Id == id & !b.IsDelete);

            if (author == null)
            {
                return NotFound();
            }

            AuthorGetDTO authorGet = _mapper.Map<AuthorGetDTO>(author);

            return Ok(authorGet);
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAll(string search=null)
        {
            var query = _context.Authors.Where(a => !a.IsDelete);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(b => b.Name.Contains(search));
            }

            AuthorListDTO authorList = new AuthorListDTO
            {
                Items = query.Select(a => new AuthorListItemDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    Image = a.Image,
                    DisplayStatus = a.DisplayStatus
                }).ToList(),
                TotalCount = query.Count()
            };

            return Ok(authorList);
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromForm] AuthorPostDTO authorPost)
        {
            Author author = new Author
            {
                Name = authorPost.Name,
                DisplayStatus = authorPost.DisplayStatus
            };

            author.Image = authorPost.Image.SaveImg(_env.WebRootPath, "assets/image");

            _context.Authors.Add(author);
            _context.SaveChanges();

            return Ok(author);
        }

        [Route("update/{id}")]
        [HttpPut]
        public IActionResult Update(int id, [FromForm] AuthorPutDTO authorPut)
        {
            Author existAuthor = _context.Authors.FirstOrDefault(b => b.Id == id);

            if (existAuthor == null)
            {
                return NotFound();
            }

            existAuthor.Name = authorPut.Name;
            Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/image", existAuthor.Image);
            existAuthor.Image = authorPut.Image.SaveImg(_env.WebRootPath, "assets/image");
            existAuthor.DisplayStatus = authorPut.DisplayStatus;

            _context.SaveChanges();
            return Ok();
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Author author = _context.Authors.FirstOrDefault(b => b.Id == id && !b.IsDelete);

            if (author == null)
            {
                return NotFound();
            }

            author.IsDelete = true;
            author.ModifiedAt = DateTime.UtcNow;
            _context.SaveChanges();

            return Ok();
        }

        [Route("{id}")]
        [HttpPatch]
        public IActionResult ChangeStatus(int id, bool status)
        {
            Author author = _context.Authors.FirstOrDefault(p => p.Id == id);

            if (author == null)
            {
                return NotFound();
            }

            author.DisplayStatus = status;
            _context.SaveChanges();

            return Ok();
        }
    }
}
