using System.ComponentModel.DataAnnotations;

namespace LetsPartyProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Sector { get; set; }
        public int DDD { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Team Team { get; set; }
    }
}

