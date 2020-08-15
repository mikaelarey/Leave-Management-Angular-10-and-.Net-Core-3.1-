using System.Linq;
using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult GetUsers()
        {
            var userRoles = _context.UserRoles.ToList();

            return Ok(userRoles);
        }
    }
}