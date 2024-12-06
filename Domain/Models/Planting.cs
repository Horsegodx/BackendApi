using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Planting
    {
        public int PlantingId { get; set; }
        public DateTime PlantingDate { get; set; }
        public int PlantId { get; set; }

        public virtual Plant Plant { get; set; } = null!;
    }
}
