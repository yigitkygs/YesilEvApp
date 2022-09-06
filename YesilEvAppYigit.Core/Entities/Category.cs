namespace YesilEvAppYigit.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [Key]
        public int KategoriID { get; set; }

        [StringLength(50)]
        public string KategoriAdi { get; set; }

        public int UstKategoriID { get; set; }
    }
}
