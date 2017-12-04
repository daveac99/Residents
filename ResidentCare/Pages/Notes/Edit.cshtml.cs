using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResidentCare.Models;

namespace ResidentCare.Pages.Notes
{
    public class EditModel : PageModel
    {
        private readonly ResidentCare.Models.ResidentContext _context;

        public EditModel(ResidentCare.Models.ResidentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Note Note { get; set; }

        [BindProperty]
        public string ScreenSource { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, string screenSource = "Index")
        {
            if (id == null)
            {
                return NotFound();
            }

            Note = await _context.Note
                .Include(n => n.Resident).SingleOrDefaultAsync(m => m.NoteId == id);
            ScreenSource = screenSource;

            if (Note == null)
            {
                return NotFound();
            }
            //ViewData["ResidentId"] = new SelectList(_context.Resident, "ResidentId", "ResidentId");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return RedirectToPage($"/Residents/{ScreenSource}",new { id = Note.ResidentId});
        }
    }
}
