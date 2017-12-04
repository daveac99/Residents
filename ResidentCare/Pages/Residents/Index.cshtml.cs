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
    public class IndexModel : PageModel
    {
        private readonly ResidentCare.Models.ResidentContext _context;

        public IndexModel(ResidentCare.Models.ResidentContext context)
        {
            _context = context;
        }

        public int? ShowNotesForResidentId { get; set; }

        [BindProperty]
        public string SearchString { get; set; }

        public IList<Resident> Resident { get; set; }

        public async Task OnGetAsync(int? showNotesForResidentId)
        {
            Resident = await _context.Resident.Include(r => r.Notes).OrderBy(r => r.LastName).ToListAsync();
            ShowNotesForResidentId = showNotesForResidentId;
        }

        public async Task OnPostAsync()
        {
            if (string.IsNullOrEmpty(SearchString))
            {
                Resident = await _context.Resident.Include(r => r.Notes)
                               .OrderBy(r => r.LastName).ToListAsync();
            }
            else
            {
                Resident = await _context.Resident.Where(r => r.LastName.ToLower().Contains(SearchString.ToLower()))
                                .Include(r => r.Notes)
                                .OrderBy(r => r.LastName).ToListAsync();
            }
        }



    }
}
