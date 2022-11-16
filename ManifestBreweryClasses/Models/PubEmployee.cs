using System;
using System.Collections.Generic;

namespace ManifestBreweryClasses.Models
{
    public partial class PubEmployee
    {
        public PubEmployee()
        {
            Accounts = new HashSet<Account>();
            Sales = new HashSet<Sale>();
        }

        public int EmployeeId { get; set; }
        public int? AppUserId { get; set; }
        public string? Name { get; set; }
        public int? PubId { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zipcode { get; set; }
        public string? Phone { get; set; }
        public string? SalesPersonName { get; set; }

        public virtual AppUser? AppUser { get; set; }
        public virtual Pub? Pub { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
