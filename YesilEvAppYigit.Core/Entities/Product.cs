namespace YesilEvAppYigit.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            FavoriUruns = new HashSet<FavoriUrun>();
            UrunAllergens = new HashSet<UrunAllergen>();
        }

        [Key]
        public int UrunID { get; set; }

        public string BarkodNo { get; set; }

        public int? BrandID { get; set; }

        [Required]
        [StringLength(50)]
        public string UrunAdi { get; set; }

        public int? KategoriID { get; set; }

        public string UrunIcerigiText { get; set; }

        [Column(TypeName = "image")]
        public byte[] UrunIcerigiImg { get; set; }

        [Column(TypeName = "image")]
        public byte[] OnYuzu { get; set; }

        [Column(TypeName = "image")]
        public byte[] ArkaYuzu { get; set; }

        public bool? IsActive { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateAdded { get; set; }

        public int AddedBy { get; set; }

        public bool? IsApproved { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FavoriUrun> FavoriUruns { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UrunAllergen> UrunAllergens { get; set; }
    }
}
