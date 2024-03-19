using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResaTicket.Data;
using ResaTicket.Model;



namespace ResaTicket.Pages.FilmsLangues
{
    public class IndexModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public IndexModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Film_Langue>? Film_Langue { get; set; }

        public int? FilmID { get; set; }
        public Film? Film { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) { return NotFound(); }
            FilmID = (int)id;
            Film = _context.Film.Find(id);
            Film_Langue = await _context.Film_Langue.
                Include(e => e.LFilm).Where(e => e.LFilm.ID == id).Include(e => e.LLangue).ToListAsync();
            if (Film_Langue == null)
            {
                // Initialiser la liste si elle est null
                Film_Langue = new List<Film_Langue>();
            }
            return Page();
        }


        /* 
           public async Task OnGetAsync()
       {
           Film_Langue = await _context.Film_Langue
               .Include(f => f.LFilm)
               .Include(f => f.LLangue).ToListAsync();
       }*/

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var filmLangue = await _context.Film_Langue.FindAsync(id);
            if (filmLangue == null)
            {
                return NotFound();
            }

            _context.Film_Langue.Remove(filmLangue);
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}

