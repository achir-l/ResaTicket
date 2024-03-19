using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResaTicket.Data;
using ResaTicket.Model;

namespace ResaTicket.Pages.SeanceS
{
    public class IndexModel : PageModel
    {
       
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public IndexModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Seance> Seance { get;set; } = default!;
        public Cinema? Cinema { get; set; }

        
        public async Task OnGetAsync(int? id)
        {
            if (id.HasValue)
            {
                Cinema = await _context.Cinema.FindAsync(id);
            }
            Seance = await _context.Seance
                .Where(s => s.CinemaID == id)
                .Include(s => s.Film)
                .Include(s => s.Cinema)
                .Include(s => s.LesTarifs)
                .Include(s => s.TypeDiffusion).ToListAsync();
        }
    }
}
