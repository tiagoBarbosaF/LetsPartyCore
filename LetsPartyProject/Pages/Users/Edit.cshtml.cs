using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LetsPartyProject.Models;
using RazorPagesUser.Data;

namespace LetsPartyProject.Pages.Users
{
  public class EditModel : PageModel
  {
    private readonly LetsPartyContext _context;

    public EditModel(LetsPartyContext context)
    {
      _context = context;
    }

    [BindProperty]
    public new User User { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      User = await _context.Users
          .Include(u => u.Team).FirstOrDefaultAsync(m => m.Id == id);

      if (User == null)
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

      _context.Attach(User).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!UserExists(User.Id))
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

    private bool UserExists(int id)
    {
      return _context.Users.Any(e => e.Id == id);
    }
  }
}
