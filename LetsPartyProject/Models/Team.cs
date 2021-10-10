using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LetsPartyProject.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Team name")]
        public string TeamName { get; set; }

        public User User { get; set; }
        public ICollection<Calendar> Calendars { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}

