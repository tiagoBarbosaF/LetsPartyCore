using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LetsPartyProject.Models;
using RazorPagesUser.Data;

namespace LetsPartyProject.Pages.Calendars
{
  public class IndexModel : PageModel
  {
    private readonly LetsPartyContext _context;

    public IndexModel(LetsPartyContext context)
    {
      _context = context;
    }

    public IList<Calendar> Calendar { get; set; }

    public async Task OnGetAsync()
    {
      Calendar = await _context.Calendars
          .Include(c => c.Team).ToListAsync();
    }
  }
}
