using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LetsPartyProject.Models;
using RazorPagesUser.Data;

namespace LetsPartyProject.Pages.Users
{
  public class DetailsModel : PageModel
  {
    private readonly LetsPartyContext _context;

    public DetailsModel(LetsPartyContext context)
    {
      _context = context;
    }

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
      return Page();
    }
  }
}
