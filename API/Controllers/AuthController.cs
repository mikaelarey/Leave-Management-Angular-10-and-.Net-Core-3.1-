using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.IRepositories;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
    }
}