namespace YesilEvAppYigit.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FavoriUrun")]
    public partial class FavoriUrun
    {
        public int ID { get; set; }

        public int FavoriID { get; set; }

        public int UrunID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateAdded { get; set; }

        public bool? IsActive { get; set; }

        public virtual Favorite Favorite { get; set; }

        public virtual Product Product { get; set; }
    }
}
