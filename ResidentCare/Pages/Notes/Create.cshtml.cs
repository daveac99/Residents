using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResidentCare.Models;

namespace ResidentCare.Pages.Notes
{
    public class CreateModel : PageModel
    {
        private readonly ResidentCare.Models.ResidentContext _context;


        public CreateModel(ResidentCare.Models.ResidentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int ResidentId { get; set; }

        public IActionResult OnGet(int residentId)
        {
            //ViewData["ResidentId"] = new SelectList(_context.Resident, "ResidentId", "ResidentId");
            ResidentId = residentId;
            return Page();
        }

        [BindProperty]
        public Note Note { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Note.ResidentId = ResidentId;
            _context.Note.Add(Note);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Residents/Index");
        }
    }
}