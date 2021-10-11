using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LetsPartyProject.Models
{
  public class Event
  {
    public int Id { get; set; }

    [Required]
    [DisplayName("Event name")]
    public string EventName { get; set; }

    [Required]
    [DisplayName("Event date")]
    public DateTime EventDate { get; set; }
    public string City { get; set; }

    [Required]
    [DisplayName("Type Event")]
    public string TypeEvent { get; set; }

    [Required]
    [DisplayName("Team")]
    public int TeamId { get; set; }

    [Required]
    [DisplayName("Calendar")]
    public int CalendarId { get; set; }

    public Team Team { get; set; }
    public Calendar Calendar { get; set; }
  }
}

