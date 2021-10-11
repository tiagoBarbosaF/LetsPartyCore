using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LetsPartyProject.Models;
using RazorPagesUser.Data;

namespace LetsPartyProject.Pages.Teams
{
  public class DeleteModel : PageModel
  {
    private readonly LetsPartyContext _context;

    public DeleteModel(LetsPartyContext context)
    {
      _context = context;
    }

    [BindProperty]
    public Team Team { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      Team = await _context.Teams.FirstOrDefaultAsync(m => m.Id == id);

      if (Team == null)
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

      Team = await _context.Teams.FindAsync(id);

      if (Team != null)
      {
        _context.Teams.Remove(Team);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}
