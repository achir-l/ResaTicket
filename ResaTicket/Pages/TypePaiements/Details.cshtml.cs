using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResaTicket.Data;
using ResaTicket.Model;

namespace ResaTicket.Pages.TypePaiements
{
    public class DetailsModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public DetailsModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public TypePaiement TypePaiement { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typepaiement = await _context.TypePaiement.FirstOrDefaultAsync(m => m.Id == id);
            if (typepaiement == null)
            {
                return NotFound();
            }
            else
            {
                TypePaiement = typepaiement;
            }
            return Page();
        }
    }
}
