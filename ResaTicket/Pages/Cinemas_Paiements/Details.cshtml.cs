using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResaTicket.Data;
using ResaTicket.Model;

namespace ResaTicket.Pages.Cinemas_Paiements
{
    public class DetailsModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public DetailsModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Cinema_Paiement Cinema_Paiement { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinema_paiement = await _context.CinemaPaiement.FirstOrDefaultAsync(m => m.ID == id);
            if (cinema_paiement == null)
            {
                return NotFound();
            }
            else
            {
                Cinema_Paiement = cinema_paiement;
            }
            return Page();
        }
    }
}
