using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LetsPartyProject.Models;
using RazorPagesUser.Data;

namespace LetsPartyProject.Pages.Teams
{
  public class CreateModel : PageModel
  {
    private readonly LetsPartyContext _context;

    public CreateModel(LetsPartyContext context)
    {
      _context = context;
    }

    public IActionResult OnGet()
    {
      return Page();
    }

    [BindProperty]
    public Team Team { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _context.Teams.Add(Team);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}
