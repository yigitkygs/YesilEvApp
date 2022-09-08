using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvAppYigit.Core;

namespace YesilEvAppYigit.DTO
{
    public class AllergenDTO
    {
        public int AllergenID { get; set; }
        [Required]
        public string AllergenName { get; set; }

        public string Description { get; set; }
        [Required]
        public int RiskID { get; set; }

        public bool? IsActive { get; set; }
        public Risk Risk { get; set; }
        public DateTime CreateDate { get; set; }

        public List<ProductAllergenDTO> ProductAllergen { get; set; }
    }
}
