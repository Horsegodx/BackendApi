using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Animal
    {
        public Animal()
        {
            FeedingSchedules = new HashSet<FeedingSchedule>();
            Users = new HashSet<User>();
        }

        public int AnimalsId { get; set; }
        public string AnimalName { get; set; } = null!;
        public DateTime? AnimalBirthDate { get; set; }
        public string AnimalType { get; set; } = null!;

        public virtual ICollection<FeedingSchedule> FeedingSchedules { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
