using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvAppYigit.DTO
{
    public class ManufacturerDTO
    {
        [DisplayName("Üretici No")]
        public int ManufacturerID { get; set; }

        [Required]
        [DisplayName("Üretici Adı")]
        public string ManufacturerName { get; set; }

        [DisplayName("Aktif mi?")]
        public bool? IsActive { get; set; }

        [DisplayName("Ekleme Tarihi")]
        public DateTime? CreateDate { get; set; }

        [Browsable(false)]
        public List<BrandDTO> Brand { get; set; }

        public override string ToString()
        {
            return ManufacturerName;
        }
    }
}
