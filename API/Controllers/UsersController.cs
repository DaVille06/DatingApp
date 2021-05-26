using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        // get all users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersAsync() 
        {
            return await _context.Users.ToListAsync();    
        }
        
        // get a specific user
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUserByIdAsync(int id) 
        {
            return await _context.Users.FindAsync(id); 
        }
    }
}