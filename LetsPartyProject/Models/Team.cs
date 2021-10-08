using System.Collections.Generic;

namespace LetsPartyProject.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<Calendar> Calendars { get; set; }
    }
}

