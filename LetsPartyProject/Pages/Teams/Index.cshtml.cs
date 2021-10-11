using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LetsPartyProject.Models;
using RazorPagesUser.Data;

namespace LetsPartyProject.Pages.Teams
{
  public class IndexModel : PageModel
  {
    private readonly LetsPartyContext _context;

    public IndexModel(LetsPartyContext context)
    {
      _context = context;
    }

    public IList<Team> Team { get; set; }

    public async Task OnGetAsync()
    {
      Team = await _context.Teams.ToListAsync();
    }
  }
}
