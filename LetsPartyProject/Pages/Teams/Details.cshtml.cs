using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LetsPartyProject.Models;
using RazorPagesUser.Data;

namespace LetsPartyProject.Pages.Teams
{
  public class DetailsModel : PageModel
  {
    private readonly LetsPartyContext _context;

    public DetailsModel(LetsPartyContext context)
    {
      _context = context;
    }

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
  }
}
