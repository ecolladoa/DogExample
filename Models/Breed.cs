using System;
using System.Collections.Generic;

namespace DogExample.Models
{
    public partial class Breed
    {
        public int BreedId { get; set; }
        public string? Name { get; set; }

        public virtual Dog Dog { get; set; } = null!;
    }
}
