using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILeaveManagementRepository _repo;
        private readonly IMapper _mapper;
        public UserController(ILeaveManagementRepository repo, DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            var userToRetun = _mapper.Map<IEnumerable<UserListDTO>>(users);
            return Ok(userToRetun);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);
            var userToRetun = _mapper.Map<UserDetailDTO>(user);
            return Ok(userToRetun);
        }
    }
}