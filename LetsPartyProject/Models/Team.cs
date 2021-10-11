using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LetsPartyProject.Models
{
  public class Team
  {
    public int Id { get; set; }

    [Required]
    [DisplayName("Team name")]
    public string TeamName { get; set; }

    [DisplayName("Quantity Members")]
    public int QuantityMembers { get; set; }

    public ICollection<User> Users { get; set; }
    public ICollection<Calendar> Calendars { get; set; }
    public ICollection<Event> Events { get; set; }
  }
}

