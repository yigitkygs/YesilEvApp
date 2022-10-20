using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvAppYigit.Core;

namespace YesilEvAppYigit.DTO
{
    public class ProductAllergenDTO
    {
        [DisplayName("ID")]
        public int ProductAllergenID { get; set; }

        [DisplayName("Ürün No")]
        [Required]
        public int ProductID { get; set; }

        [DisplayName("Aktif mi?")]
        public bool? IsActive { get; set; }

        [Required]
        [DisplayName("Alerjen ID")]
        public int AllergenID { get; set; }

        [DisplayName("Eklenme tarihi")]
        public DateTime? CreateDate { get; set; }

        [Browsable(false)]
        public AllergenDTO Allergen { get; set; }

        [Browsable(false)]
        public ProductDTO Product { get; set; }

        public override string ToString()
        {
            return Allergen.AllergenName;
        }
    }
}
