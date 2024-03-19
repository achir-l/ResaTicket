using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResaTicket.Data;
using ResaTicket.Model;


namespace ResaTicket.Pages.Films
{
    public class CreateModel : PageModel
    {
        private readonly ResaTicket.Data.ApplicationDbContext _context;

        public CreateModel(ResaTicket.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            ViewData["LangueID"] = new SelectList(_context.Langue, "ID", "Nom");
            return Page();
        }


        [BindProperty]
        public Film Film { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Film.Add(Film);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

