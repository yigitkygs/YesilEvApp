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
        public int ProductAllergenID { get; set; }

        [Required]
        public int ProductID { get; set; }
        public bool? IsActive { get; set; }

        [Required]
        public int AllergenID { get; set; }
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
