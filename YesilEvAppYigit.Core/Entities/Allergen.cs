namespace YesilEvAppYigit.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Allergen")]
    public partial class Allergen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Allergen()
        {
            BlacklistAllergens = new HashSet<BlacklistAllergen>();
            ProductAllergens = new HashSet<ProductAllergen>();
        }

        [Key]
        public int AllergenID { get; set; }

        [Required]
        [StringLength(50)]
        public string AllergenName { get; set; }

        public string Description { get; set; }

        public int? RiskID { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Risk Risk { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlacklistAllergen> BlacklistAllergens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductAllergen> ProductAllergens { get; set; }
    }
}
