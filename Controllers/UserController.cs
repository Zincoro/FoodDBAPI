using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodAPI
{
    // Route is /User
    [Route("/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FoodRecipesContext _context;

        public UserController(FoodRecipesContext context) => _context = context;

        // GET: /User/27036778&lol
        [HttpGet("{userName}&{pwrd}")]
        public async Task<ActionResult<UserTable>> GetUser(string userName, string pwrd) => await _context.UserTable.Where(e => e.Username == userName && e.Pword == pwrd ).FirstOrDefaultAsync();

        // POST: /SavedUser
        [HttpPost]
        public async Task<ActionResult> PostUser(UserTable savedUser)
        {
            _context.UserTable.Add(savedUser);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
