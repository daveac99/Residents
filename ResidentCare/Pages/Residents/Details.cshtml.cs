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
    public class DetailsModel : PageModel
    {
        private readonly ResidentCare.Models.ResidentContext _context;

        public DetailsModel(ResidentCare.Models.ResidentContext context)
        {
            _context = context;
        }

        public Resident Resident { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resident = await _context.Resident.Include(r => r.Notes).SingleOrDefaultAsync(m => m.ResidentId == id);
               

            if (Resident == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
