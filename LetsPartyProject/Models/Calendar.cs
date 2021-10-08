namespace LetsPartyProject.Models
{
    public class Calendar
    {
        public int Id { get; set; }
        public string CalendarName { get; set; }
        public int Day { get; set; }
        public int TeamId { get; set; }

        public Team Team { get; set; }
    }
}

