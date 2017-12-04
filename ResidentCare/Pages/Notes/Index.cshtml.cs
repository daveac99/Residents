using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResidentCare.Models;

namespace ResidentCare.Pages.Notes
{
    public class IndexModel : PageModel
    {
        private readonly ResidentCare.Models.ResidentContext _context;

        public IndexModel(ResidentCare.Models.ResidentContext context)
        {
            _context = context;
        }

        public IList<Note> Note { get; set; }

        public async Task OnGetAsync(int residentId)
        {
            if (residentId == 0)
            {
                Note = await _context.Note
                .Include(n => n.Resident).ToListAsync();
            }
            else
            {
                Note = await _context.Note.Where(n => n.ResidentId == residentId)
                               .Include(n => n.Resident).ToListAsync();
            }

        }
    }
}
