namespace YesilEvAppYigit.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Brand")]
    public partial class Brand
    {
        public int BrandID { get; set; }

        [Required]
        [StringLength(50)]
        public string BrandName { get; set; }

        public int? ManufacturerID { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public DateTime? CreateDate { get; set; }

        public bool? IsActive { get; set; }
    }
}
