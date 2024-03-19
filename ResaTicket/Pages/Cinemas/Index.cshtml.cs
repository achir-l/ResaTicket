using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResaTicket.Data;
using ResaTicket.Model;



namespace ResaTicket.Pages.Cinemas
{
    public class IndexModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public IndexModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Cinema> Cinema { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Cinema = await _context.Cinema.ToListAsync();
        }
    }
}


