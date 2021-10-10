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

    public DbSet<User> Users { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Calendar> Calendars { get; set; }
  }
}
