using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models.DTO;

namespace WebApplication2.Controllers.App
{
    public class UsersController : Controller
    {
        private readonly TestDbContext _context;

        public UsersController(TestDbContext context)
        {
            _context = context;
        }

        public ViewResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterUserDTO newUser)
        {
            return RedirectToRoute("api/Users/Register", newUser);
            //await RedirectToAction("Register", "Users", newUser);
        }
        public ViewResult Login ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDTO rUser)
        {
            return RedirectToRoute("api/Users/Login", rUser);
        }
        // GET: Users
        public async Task<IActionResult> Index()
        {
              return View(await _context.UserDto.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.UserDto == null)
            {
                return NotFound();
            }

            var userDto = await _context.UserDto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userDto == null)
            {
                return NotFound();
            }

            return View(userDto);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username")] UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userDto);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.UserDto == null)
            {
                return NotFound();
            }

            var userDto = await _context.UserDto.FindAsync(id);
            if (userDto == null)
            {
                return NotFound();
            }
            return View(userDto);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Username")] UserDto userDto)
        {
            if (id != userDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userDto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDtoExists(userDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userDto);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.UserDto == null)
            {
                return NotFound();
            }

            var userDto = await _context.UserDto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userDto == null)
            {
                return NotFound();
            }

            return View(userDto);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.UserDto == null)
            {
                return Problem("Entity set 'TestDbContext.UserDto'  is null.");
            }
            var userDto = await _context.UserDto.FindAsync(id);
            if (userDto != null)
            {
                _context.UserDto.Remove(userDto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserDtoExists(string id)
        {
          return _context.UserDto.Any(e => e.Id == id);
        }
    }
}
