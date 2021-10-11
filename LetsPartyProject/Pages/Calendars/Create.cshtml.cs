using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LetsPartyProject.Models;
using RazorPagesUser.Data;

namespace LetsPartyProject.Pages.Calendars
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
      ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "TeamName");
      return Page();
    }

    [BindProperty]
    public Calendar Calendar { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _context.Calendars.Add(Calendar);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}
