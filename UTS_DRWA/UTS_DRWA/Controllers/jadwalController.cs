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
    public class jadwalController : ControllerBase
    {
        private readonly TodoContextjadwal _context;

        public jadwalController(TodoContextjadwal context)
        {
            _context = context;
        }

                // POST: api/jadwal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Todoguru>> PostTodoguru(jadwalguru jadwalguru)
    {
    _context.jadwalguru.Add(jadwalguru);
    await _context.SaveChangesAsync();

    //    return CreatedAtAction("Getjadwalguru", new { nip = jadwalguru.nip }, jadwalguru);
    return CreatedAtAction(nameof(Getjadwalguru), new { nip = jadwalguru.nip }, jadwalguru);
}

        // GET: api/jadwal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<jadwalguru>>> Getjadwalguru()
        {
          if (_context.jadwalguru == null)
          {
              return NotFound();
          }
            return await _context.jadwalguru.ToListAsync();
        }

        // GET: api/jadwal/5
        [HttpGet("{nip}")]
        public async Task<ActionResult<jadwalguru>> Getjadwalguru(long nip)
        {
          if (_context.jadwalguru == null)
          {
              return NotFound();
          }
            var jadwalguru = await _context.jadwalguru.FindAsync(nip);

            if (jadwalguru == null)
            {
                return NotFound();
            }

            return jadwalguru;
        }


           /* GET: api/jadwal/5
        [HttpGet("{id_mapel}")]
        public async Task<ActionResult<jadwalguru>> Getjadwalguru(long id_mapel)
        {
          if (_context.jadwalguru == null)
          {
              return NotFound();
          }
            var jadwalguru = await _context.jadwalguru.FindAsync(id_mapel);

            if (jadwalguru == null)
            {
                return NotFound();
            }

            return jadwalguru;
        }*/
   



        
    }
}
