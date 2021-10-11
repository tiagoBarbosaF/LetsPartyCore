using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LetsPartyProject.Models;
using RazorPagesUser.Data;

namespace LetsPartyProject.Pages.Events
{
  public class EditModel : PageModel
  {
    private readonly LetsPartyContext _context;

    public EditModel(LetsPartyContext context)
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
      ViewData["CalendarId"] = new SelectList(_context.Calendars, "Id", "CalendarName");
      ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "TeamName");
      return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _context.Attach(Event).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!EventExists(Event.Id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return RedirectToPage("./Index");
    }

    private bool EventExists(int id)
    {
      return _context.Events.Any(e => e.Id == id);
    }
  }
}
