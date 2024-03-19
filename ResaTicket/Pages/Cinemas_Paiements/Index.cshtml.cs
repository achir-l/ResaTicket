using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using ResaTicket.Data;
using ResaTicket.Model;

namespace ResaTicket.Pages.Cinemas_Paiements
{
    public class IndexModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public IndexModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Cinema_Paiement>? CinemaPaiement { get;set; } = default!;

        public int? CinemaID { get; set; }
        public Cinema? Cinema { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CinemaID = (int)id;
            Cinema = await _context.Cinema.FindAsync(id);

            // Vérifiez si le cinéma existe
            if (Cinema == null)
            {
                return NotFound();
            }

            CinemaPaiement = await _context.CinemaPaiement
                .Include(e => e.TCinema)
                .Include(e => e.TTypePaiement)
                .Where(e => e.TCinema.ID == id)
                .ToListAsync();

            if (CinemaPaiement == null)
            {
                // Initialiser la liste si elle est null
                CinemaPaiement = new List<Cinema_Paiement>();
            }

            return Page();
        }

    }
}
