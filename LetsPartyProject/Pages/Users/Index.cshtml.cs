using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LetsPartyProject.Models;
using RazorPagesUser.Data;

namespace LetsPartyProject.Pages.Users
{
  public class IndexModel : PageModel
  {
    private readonly LetsPartyContext _context;

    public IndexModel(LetsPartyContext context)
    {
      _context = context;
    }

    public new IList<User> User { get; set; }

    public async Task OnGetAsync()
    {
      User = await _context.Users
          .Include(u => u.Team).ToListAsync();
    }
  }
}
