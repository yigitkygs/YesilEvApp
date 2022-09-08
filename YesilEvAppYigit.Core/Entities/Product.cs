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
            FavoriteProducts = new HashSet<FavoriteProduct>();
            ProductAllergens = new HashSet<ProductAllergen>();
        }

        [Key]
        public int ProductID { get; set; }

        public string BarcodeNo { get; set; }

        public int? BrandID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public int? CategoryID { get; set; }

        public string ProductIngredientsText { get; set; }

        [Column(TypeName = "image")]
        public byte[] ProductIngredientsImg { get; set; }

        [Column(TypeName = "image")]
        public byte[] FrontImg { get; set; }

        [Column(TypeName = "image")]
        public byte[] BackImg { get; set; }

        public bool? IsActive { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; }

        public int AddedBy { get; set; }

        public bool? IsApproved { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FavoriteProduct> FavoriteProducts { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductAllergen> ProductAllergens { get; set; }
    }
}
