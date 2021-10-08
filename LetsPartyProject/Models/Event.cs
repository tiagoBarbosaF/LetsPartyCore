using System;
using System.ComponentModel.DataAnnotations;

namespace LetsPartyProject.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }

        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }
        public int CalendarId { get; set; }

        public Calendar Calendar { get; set; }
    }
}

