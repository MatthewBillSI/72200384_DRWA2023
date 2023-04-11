using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UTS_DRWA.Models;

namespace UTS_DRWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodomapelController : ControllerBase
    {
        private readonly TodoContextmapel _context;

        public TodomapelController(TodoContextmapel context)
        {
            _context = context;
        }
        // POST: api/Todomapel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
       public async Task<ActionResult<Todomapel>> PostTodoguru(Todomapel todomapel)
    {
    _context.Todomapel.Add(todomapel);
    await _context.SaveChangesAsync();

    //    return CreatedAtAction("GetTodomapel", new { id = todomapel.id }, todomapel);
    return CreatedAtAction(nameof(GetTodomapel), new { id = todomapel.id }, todomapel);
}



        // GET: api/Todomapel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todomapel>>> GetTodomapel()
        {
          if (_context.Todomapel == null)
          {
              return NotFound();
          }
            return await _context.Todomapel.ToListAsync();
        }

        // GET: api/Todomapel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todomapel>> GetTodomapel(long id)
        {
          if (_context.Todomapel == null)
          {
              return NotFound();
          }
            var todomapel = await _context.Todomapel.FindAsync(id);

            if (todomapel == null)
            {
                return NotFound();
            }

            return todomapel;
        }

        // PUT: api/Todomapel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       
        

    }
    
}
