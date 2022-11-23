using System;
using System.Collections.Generic;

namespace ManifestBreweryClasses.Models
{
    public partial class Pub
    {
        public Pub()
        {
            PubEmployees = new HashSet<PubEmployee>();
        }

        public int PubId { get; set; }
        public string? PubAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zipcode { get; set; }
        public string? Phone { get; set; }
        public string? ManagerName { get; set; }

        public virtual ICollection<PubEmployee> PubEmployees { get; set; }
    }
}
