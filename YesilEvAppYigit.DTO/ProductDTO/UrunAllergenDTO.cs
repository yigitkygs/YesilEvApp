using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvAppYigit.Core;

namespace YesilEvAppYigit.DTO
{
    public class UrunAllergenDTO
    {
        public int ID { get; set; }

        [Required]
        public int UrunID { get; set; }

        [Required]
        public int AllergenID { get; set; }

        public AllergenDTO Allergen { get; set; }

        public ProductDTO Product { get; set; }

        
    }
}
