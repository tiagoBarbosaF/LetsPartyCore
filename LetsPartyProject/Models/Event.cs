using System;
using System.Collections.Generic;
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
    public int TeamId { get; set; }
    public int CalendarId { get; set; }

    public Team Team { get; set; }
    public Calendar Calendar { get; set; }
  }
}

