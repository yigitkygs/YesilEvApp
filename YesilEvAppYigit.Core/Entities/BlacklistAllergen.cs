namespace YesilEvAppYigit.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BlacklistAllergen")]
    public partial class BlacklistAllergen
    {
        public int BlacklistAllergenID { get; set; }

        public int BlacklistID { get; set; }

        public int AllergenID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public bool? IsActive { get; set; }

        public virtual Allergen Allergen { get; set; }

        public virtual Blacklist Blacklist { get; set; }
    }
}
