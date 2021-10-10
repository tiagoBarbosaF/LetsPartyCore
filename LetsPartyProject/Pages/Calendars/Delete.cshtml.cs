using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LetsPartyProject.Models;
using RazorPagesUser.Data;

namespace LetsPartyProject.Pages.Calendars
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesUser.Data.LetsPartyContext _context;

        public DeleteModel(RazorPagesUser.Data.LetsPartyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Calendar Calendar { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Calendar = await _context.Calendars
                .Include(c => c.Team).FirstOrDefaultAsync(m => m.Id == id);

            if (Calendar == null)
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

            Calendar = await _context.Calendars.FindAsync(id);

            if (Calendar != null)
            {
                _context.Calendars.Remove(Calendar);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
