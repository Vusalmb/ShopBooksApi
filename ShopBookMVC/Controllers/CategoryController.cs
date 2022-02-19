using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopBookMVC.DTOs;
using ShopBooksApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShopBookMVC.Controllers
{
    public class CategoryController : Controller
    {
        public async Task<IActionResult> Index(int page=1)
        {
            CategoryListDTO categoryList;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:44386/admin/api/books/all");
                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    categoryList = JsonConvert.DeserializeObject<CategoryListDTO>(responseStr);
                    return View(categoryList);
                }
            }

            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> Detail()
        {
            CategoryListDTO categoryList;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:44386/admin/api/books/all");
                var responseStr = await response.Content.ReadAsStringAsync();
                categoryList = JsonConvert.DeserializeObject<CategoryListDTO>(responseStr);
            }

            return View(categoryList);
        }
    }
}
