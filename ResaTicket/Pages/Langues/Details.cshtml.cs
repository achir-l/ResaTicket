using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResaTicket.Data;
using ResaTicket.Model;

namespace ResaTicket.Pages.Langues
{
    public class DetailsModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public DetailsModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Langue Langue { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var langue = await _context.Langue.FirstOrDefaultAsync(m => m.ID == id);
            if (langue == null)
            {
                return NotFound();
            }
            else
            {
                Langue = langue;
            }
            return Page();
        }
    }
}
