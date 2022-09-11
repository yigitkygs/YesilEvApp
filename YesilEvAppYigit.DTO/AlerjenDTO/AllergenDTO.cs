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
    public class AllergenDTO
    {
        [DisplayName("Alerjen No")]
        public int AllergenID { get; set; }
        [Required]
        [DisplayName("Alerjen Adı")]
        public string AllergenName { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Risk No")]
        public int RiskID { get; set; }

        [DisplayName("Aktif mi?")]
        public bool? IsActive { get; set; }

        [Browsable(false)]
        public Risk Risk { get; set; }

        [DisplayName("Eklenme Tarihi")]
        public DateTime CreateDate { get; set; }

        [Browsable(false)]
        public List<ProductAllergenDTO> ProductAllergen { get; set; }

        public override string ToString()
        {
            return AllergenName;
        }
    }
}
