using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LetsPartyProject.Models
{
  public class Calendar
  {
    public int Id { get; set; }

    [Required]
    [DisplayName("Calendar Name")]
    public string CalendarName { get; set; }
    public int TeamId { get; set; }

    public Team Team { get; set; }
    public ICollection<Event> Events { get; set; }
  }
}

