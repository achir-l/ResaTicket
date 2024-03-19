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

namespace ResaTicket.Pages.TypePaiements
{
    public class IndexModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public IndexModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TypePaiement> TypePaiement { get;set; } = default!;

      

        public async Task OnGetAsync()
        {
            TypePaiement = await _context.TypePaiement.ToListAsync();

            
        }
    }
}
