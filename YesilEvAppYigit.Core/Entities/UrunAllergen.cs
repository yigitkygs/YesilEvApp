namespace YesilEvAppYigit.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UrunAllergen")]
    public partial class UrunAllergen
    {
        public int ID { get; set; }

        public int UrunID { get; set; }

        public int AllergenID { get; set; }

        public virtual Allergen Allergen { get; set; }

        public virtual Product Product { get; set; }
    }
}
