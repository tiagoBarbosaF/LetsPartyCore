using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LetsPartyProject.Models;
using RazorPagesUser.Data;

namespace LetsPartyProject.Pages.Events
{
  public class CreateModel : PageModel
  {
    private readonly LetsPartyContext _context;

    public CreateModel(LetsPartyContext context)
    {
      _context = context;
    }

    public IActionResult OnGet()
    {
      ViewData["CalendarName"] = new SelectList(_context.Calendars, "Id", "CalendarName");
      ViewData["TeamName"] = new SelectList(_context.Teams, "Id", "TeamName");
      return Page();
    }

    [BindProperty]
    public Event Event { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _context.Events.Add(Event);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}
