using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Plant
    {
        public Plant()
        {
            Fertilizations = new HashSet<Fertilization>();
            Harvests = new HashSet<Harvest>();
            Plantings = new HashSet<Planting>();
            WateringSchedules = new HashSet<WateringSchedule>();
            Users = new HashSet<User>();
        }

        public int PlantId { get; set; }
        public string PlantName { get; set; } = null!;
        public string PlantType { get; set; } = null!;

        public virtual ICollection<Fertilization> Fertilizations { get; set; }
        public virtual ICollection<Harvest> Harvests { get; set; }
        public virtual ICollection<Planting> Plantings { get; set; }
        public virtual ICollection<WateringSchedule> WateringSchedules { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
