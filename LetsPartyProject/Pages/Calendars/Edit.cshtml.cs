using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LetsPartyProject.Models;
using RazorPagesUser.Data;

namespace LetsPartyProject.Pages.Calendars
{
  public class EditModel : PageModel
  {
    private readonly LetsPartyContext _context;

    public EditModel(LetsPartyContext context)
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
      ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "TeamName");
      return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _context.Attach(Calendar).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CalendarExists(Calendar.Id))
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

    private bool CalendarExists(int id)
    {
      return _context.Calendars.Any(e => e.Id == id);
    }
  }
}
