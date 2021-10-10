using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LetsPartyProject.Models;
using RazorPagesUser.Data;

namespace LetsPartyProject.Pages.Events
{
  public class DeleteModel : PageModel
  {
    private readonly RazorPagesUser.Data.LetsPartyContext _context;

    public DeleteModel(RazorPagesUser.Data.LetsPartyContext context)
    {
      _context = context;
    }

    [BindProperty]
    public Event Event { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      Event = await _context.Events
          .Include(e => e.Calendar)
          .Include(e => e.Team).FirstOrDefaultAsync(m => m.Id == id);

      if (Event == null)
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

      Event = await _context.Events.FindAsync(id);

      if (Event != null)
      {
        _context.Events.Remove(Event);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}
