using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResidentCare.Models;

namespace ResidentCare.Pages.Residents
{
    public class DeleteModel : PageModel
    {
        private readonly ResidentCare.Models.ResidentContext _context;

        public DeleteModel(ResidentCare.Models.ResidentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Resident Resident { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resident = await _context.Resident.SingleOrDefaultAsync(m => m.ResidentId == id);

            if (Resident == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resident = await _context.Resident.FindAsync(id);

            if (Resident != null)
            {
                _context.Resident.Remove(Resident);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
