﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResaTicket.Data;
using ResaTicket.Model;

namespace ResaTicket.Pages.TypePaiements
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
            return Page();
        }

        [BindProperty]
        public TypePaiement TypePaiement { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TypePaiement.Add(TypePaiement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}