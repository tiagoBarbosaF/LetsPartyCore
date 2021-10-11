using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LetsPartyProject.Models;
using RazorPagesUser.Data;

namespace LetsPartyProject.Pages.Events
{
  public class IndexModel : PageModel
  {
    private readonly LetsPartyContext _context;

    public IndexModel(LetsPartyContext context)
    {
      _context = context;
    }

    public IList<Event> Event { get; set; }

    public async Task OnGetAsync()
    {
      Event = await _context.Events
          .Include(e => e.Calendar)
          .Include(e => e.Team).ToListAsync();
    }
  }
}
