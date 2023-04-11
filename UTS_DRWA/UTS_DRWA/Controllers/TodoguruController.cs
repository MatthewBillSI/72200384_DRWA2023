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
    public class TodoguruController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoguruController(TodoContext context)
        {
            _context = context;
        }


          [HttpPost]
        public async Task<ActionResult<Todoguru>> PostTodoguru(Todoguru todoguru)
    {
    _context.Todoguru.Add(todoguru);
    await _context.SaveChangesAsync();

    //    return CreatedAtAction("GetTodoguru", new { nip = todoguru.nip }, todoguru);
    return CreatedAtAction(nameof(GetTodoguru), new { nip = todoguru.nip }, todoguru);
}


        // GET: api/Todoguru
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todoguru>>> GetTodoguru()
        {
          if (_context.Todoguru == null)
          {
              return NotFound();
          }
            return await _context.Todoguru.ToListAsync();
        }

        // GET: api/Todoguru/5
        [HttpGet("{nip}")]
        public async Task<ActionResult<Todoguru>> GetTodoguru(long nip)
        {
          if (_context.Todoguru == null)
          {
              return NotFound();
          }
            var todoguru = await _context.Todoguru.FindAsync(nip);

            if (todoguru == null)
            {
                return NotFound();
            }

            return todoguru;
        }


     
}


    }

