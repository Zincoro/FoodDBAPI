using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodAPI.Models;

namespace FoodAPI.Controllers
{
    // Route is /SavedFood
    [Route("/[controller]")]
    [ApiController]
    public class SavedFoodController : ControllerBase
    {
        private readonly FoodRecipesContext _context;

        public SavedFoodController(FoodRecipesContext context) => _context = context;

        // GET: /SavedFood/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SavedFoodTable>>> GetByUid(int id) => await _context.SavedFoodTable.Where(e => e.Uid == id).ToListAsync(); 

        // POST: /SavedFood
        [HttpPost]
        public async Task<ActionResult> PostFood(SavedFoodTable savedFood)
        {
            _context.SavedFoodTable.Add(savedFood);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: /SavedFood/1
        [HttpDelete("{id}")]
       public async Task<ActionResult> DeleteFood(int id)
        {
            var food = await _context.SavedFoodTable.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            _context.SavedFoodTable.Remove(food);
            await _context.SaveChangesAsync();

            return Ok();
        }


    }
}
