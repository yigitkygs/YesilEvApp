namespace YesilEvAppYigit.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductAllergen")]
    public partial class ProductAllergen
    {
        public int ProductAllergenID { get; set; }

        public int ProductID { get; set; }

        public int AllergenID { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Allergen Allergen { get; set; }

        public virtual Product Product { get; set; }
    }
}
