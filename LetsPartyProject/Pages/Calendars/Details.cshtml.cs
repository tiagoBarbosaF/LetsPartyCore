using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LetsPartyProject.Models;
using RazorPagesUser.Data;

namespace LetsPartyProject.Pages.Calendars
{
  public class DetailsModel : PageModel
  {
    private readonly LetsPartyContext _context;

    public DetailsModel(LetsPartyContext context)
    {
      _context = context;
    }

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
  }
}
