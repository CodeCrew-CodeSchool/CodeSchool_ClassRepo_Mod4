using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Models.DTO;
using WebApplication2.Models.Interfaces;

namespace WebApplication2.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TestDbContext _context;
        private IUser _user;
        public UsersController(TestDbContext context)
        {
            _context = context;
        }
        public UsersController(IUser context)
        {
            _user = context;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterUserDTO data)
        {
            //Note: data (RegisterUser) comes from an inbound DTO/Model created for this purpose
            //this.ModelState ? This comes from MVC Binding and shares an interface with the Model
            var user = await _user.Register(data, this.ModelState);
            if (ModelState.IsValid)
            {
                return user;
            }

            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDTO data)
        {
            var user = await _user.Authenticate(data.Username, data.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            return user;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUserDto()
        {
            return await _context.UserDto.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserDto(string id)
        {
            var userDto = await _context.UserDto.FindAsync(id);

            if (userDto == null)
            {
                return NotFound();
            }

            return userDto;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDto(string id, UserDto userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(userDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDtoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUserDto(UserDto userDto)
        {
            _context.UserDto.Add(userDto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserDtoExists(userDto.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserDto", new { id = userDto.Id }, userDto);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDto(string id)
        {
            var userDto = await _context.UserDto.FindAsync(id);
            if (userDto == null)
            {
                return NotFound();
            }

            _context.UserDto.Remove(userDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserDtoExists(string id)
        {
            return _context.UserDto.Any(e => e.Id == id);
        }
    }
}
