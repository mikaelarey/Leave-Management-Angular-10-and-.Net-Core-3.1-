using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.IRepositories;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly DataContext _context;

        public AuthController(IAuthRepository repo, IConfiguration config, DataContext context)
        {
            _context = context;
            _config = config;
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDTO user)
        {
            user.Username = user.Username.ToLower();

            if (await _repo.UserExists(user.Username))
                return BadRequest("Username already exists");

            var newUser = new UserAccount
            {
                Username = user.Username
            };

            var createdUser = await _repo.Register(newUser, user.Password);

            return StatusCode(201);
        }

        [HttpGet("get-admin")]
        public async Task<IActionResult> GetAdmin()
        {
            var count = await _context.UserAccounts.AnyAsync(u => u.UserRoleId == 1);

            return Ok(count);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDTO user)
        {
            if (user.Username == null)
                return Unauthorized();

            var userLogin = await _repo.Login(user.Username.ToLower(), user.Password);

            if (userLogin == null)
                return Unauthorized();

            var claims = new []
            {
                new Claim(ClaimTypes.NameIdentifier, userLogin.UserRoleId.ToString()),
                new Claim(ClaimTypes.Name, userLogin.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}