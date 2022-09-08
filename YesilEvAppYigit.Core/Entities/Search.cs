namespace YesilEvAppYigit.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Search")]
    public partial class Search
    {
        [Key]
        public int SearchID { get; set; }

        [StringLength(50)]
        public string SearchKeyword { get; set; }

        public int? UserID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SearchDate { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual User User { get; set; }
    }
}
