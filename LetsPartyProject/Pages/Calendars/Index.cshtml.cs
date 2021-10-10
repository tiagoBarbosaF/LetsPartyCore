using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LetsPartyProject.Models;
using RazorPagesUser.Data;

namespace LetsPartyProject.Pages.Calendars
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesUser.Data.LetsPartyContext _context;

        public IndexModel(RazorPagesUser.Data.LetsPartyContext context)
        {
            _context = context;
        }

        public IList<Calendar> Calendar { get;set; }

        public async Task OnGetAsync()
        {
            Calendar = await _context.Calendars
                .Include(c => c.Team).ToListAsync();
        }
    }
}
