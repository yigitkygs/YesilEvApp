namespace YesilEvAppYigit.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FavoriteProduct")]
    public partial class FavoriteProduct
    {
        public int FavoriteProductID { get; set; }

        public int FavoriteID { get; set; }

        public int ProductID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public bool? IsActive { get; set; }

        public virtual Favorite Favorite { get; set; }

        public virtual Product Product { get; set; }
    }
}
