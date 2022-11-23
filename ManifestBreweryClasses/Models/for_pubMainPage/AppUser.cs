using System;
using System.Collections.Generic;

namespace ManifestBreweryClasses.Models
{
    public partial class AppUser
    {
        public AppUser()
        {
            InventoryTransactions = new HashSet<InventoryTransaction>();
            PubEmployees = new HashSet<PubEmployee>();
        }

        public int AppUserId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; }
        public virtual ICollection<PubEmployee> PubEmployees { get; set; }
    }
}
