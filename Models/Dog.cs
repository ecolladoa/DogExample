using System;
using System.Collections.Generic;

namespace DogExample.Models
{
    public partial class Dog
    {
        public int DogId { get; set; }
        public string? Name { get; set; }
        public int? BreedId { get; set; }
        public DateTime? BirthDate { get; set; }

        public virtual Breed DogNavigation { get; set; } = null!;
    }
}
