using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class User
    {
        public User()
        {
            Announcements = new HashSet<Announcement>();
            Messages = new HashSet<Message>();
            News = new HashSet<News>();
            Payments = new HashSet<Payment>();
            PollAnswers = new HashSet<PollAnswer>();
            Snts = new HashSet<Snt>();
            Animals = new HashSet<Animal>();
            Plants = new HashSet<Plant>();
            Shops = new HashSet<Shop>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<PollAnswer> PollAnswers { get; set; }
        public virtual ICollection<Snt> Snts { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
        public virtual ICollection<Plant> Plants { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
    }
}
