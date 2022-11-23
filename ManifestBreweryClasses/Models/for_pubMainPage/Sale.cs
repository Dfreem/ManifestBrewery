using System;
using System.Collections.Generic;

namespace ManifestBreweryClasses.Models
{
    public partial class Sale
    {
        public int SaleId { get; set; }
        public DateOnly? SaleDate { get; set; }
        public int EmployeeId { get; set; }
        public decimal? TotalAmnt { get; set; }
        public decimal? TaxAmnt { get; set; }

        public virtual PubEmployee Employee { get; set; } = null!;
    }
}
