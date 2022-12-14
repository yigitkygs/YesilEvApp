namespace YesilEvAppYigit.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Favorite")]
    public partial class Favorite
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Favorite()
        {
            FavoriteProducts = new HashSet<FavoriteProduct>();
        }

        [Key]
        public int FavoriteID { get; set; }

        [StringLength(50)]
        public string FavoriteName { get; set; }

        public int UserID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public bool? IsActive { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FavoriteProduct> FavoriteProducts { get; set; }
    }
}
