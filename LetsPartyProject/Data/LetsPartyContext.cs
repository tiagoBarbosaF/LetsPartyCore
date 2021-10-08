using Microsoft.EntityFrameworkCore;
using LetsPartyProject.Models;

namespace RazorPagesUser.Data
{
    public class LetsPartyContext : DbContext
    {
        public LetsPartyContext(DbContextOptions<LetsPartyContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
