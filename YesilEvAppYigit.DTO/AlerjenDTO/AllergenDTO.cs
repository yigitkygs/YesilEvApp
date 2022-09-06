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
        public int AlerjenID { get; set; }
        [Required]
        public string AlerjenAdi { get; set; }

        public string Aciklama { get; set; }
        [Required]
        public int RiskID { get; set; }

        public Risk Risk { get; set; }

        public List<UrunAllergenDTO> UrunAllergen { get; set; }
    }
}
