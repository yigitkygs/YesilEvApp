namespace YesilEvAppYigit.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Risk")]
    public partial class Risk
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Risk()
        {
            Allergens = new HashSet<Allergen>();
        }

        public int RiskID { get; set; }

        [Required]
        [StringLength(50)]
        public string RiskType { get; set; }
        public DateTime CreateDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Allergen> Allergens { get; set; }

        public override string ToString()
        {
            return RiskType;
        }
    }
}
