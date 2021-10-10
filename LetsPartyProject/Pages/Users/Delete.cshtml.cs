using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LetsPartyProject.Models;
using RazorPagesUser.Data;

namespace LetsPartyProject.Pages.Users
{
  public class DeleteModel : PageModel
  {
    private readonly RazorPagesUser.Data.LetsPartyContext _context;

    public DeleteModel(RazorPagesUser.Data.LetsPartyContext context)
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
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      User = await _context.Users.FindAsync(id);

      if (User != null)
      {
        _context.Users.Remove(User);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}
