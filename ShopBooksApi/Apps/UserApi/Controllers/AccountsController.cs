using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShopBooksApi.Apps.UserApi.DTOs.AccountDTOs;
using ShopBooksApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShopBooksApi.Apps.UserApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AccountsController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        //[Route("roles")]
        //[HttpGet]
        //public async Task<IActionResult> CreateRoles()
        //{
        //    var result = await _roleManager.CreateAsync(new IdentityRole("Member"));
        //    result = await _roleManager.CreateAsync(new IdentityRole("Admin"));
        //    result = await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));

        //    return Ok();
        //}

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            AppUser user = await _userManager.FindByNameAsync(registerDTO.UserName);

            if(user != null)
            {
                return StatusCode(409);
            }

            user = new AppUser
            {
                UserName = registerDTO.UserName,
                Fullname = registerDTO.FullName
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var resultRole = await _userManager.AddToRoleAsync(user, "Member");

            if (!resultRole.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            AppUser user = await _userManager.FindByNameAsync(loginDTO.UserName);

            if (user == null)
            {
                return NotFound();
            }

            if (!await _userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                return NotFound();
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList());
            string keyStr = "a533a0d5-3d97-4ba1-b72f-e5836706846c";

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(keyStr));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                    claims: claims,
                    signingCredentials: creds,
                    expires: DateTime.Now.AddDays(5),
                    issuer: "https://localhost:44386",
                    audience: "https://localhost:44386"
                );

            string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = tokenStr });
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Get()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            AccountGetDTO accountGet = _mapper.Map<AccountGetDTO>(user);

            return Ok(accountGet);
        }
    }
}
