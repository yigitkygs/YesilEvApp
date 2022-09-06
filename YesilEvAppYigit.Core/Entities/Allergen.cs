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
            UrunAllergens = new HashSet<UrunAllergen>();
        }

        [Key]
        public int AlerjenID { get; set; }

        [Required]
        [StringLength(50)]
        public string AlerjenAdi { get; set; }

        public string Aciklama { get; set; }

        public int? RiskID { get; set; }

        public virtual Risk Risk { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlacklistAllergen> BlacklistAllergens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UrunAllergen> UrunAllergens { get; set; }
    }
}
