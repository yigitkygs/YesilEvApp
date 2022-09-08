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
        public int CategoryID { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        public int UpperCategoryID { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }


    }
}
