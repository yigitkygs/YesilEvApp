using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvAppYigit.DTO
{
    public class BrandDTO
    {
        [DisplayName("Marka ID")]
        public int BrandID { get; set; }

        [Required]
        [DisplayName("Marka Adı")]
        public string BrandName { get; set; }

        [Required]
        [DisplayName("Üretici ID")]
        public int ManufacturerID { get; set; }

        [Browsable(false)]
        public ManufacturerDTO Manufacturer { get; set; }

        [DisplayName("Aktif mi")]
        public bool? IsActive { get; set; }

        [DisplayName("Ekleme tarihi")]
        public DateTime? CreateDate { get; set; }

        public override string ToString()
        {
            return BrandName;
        }
    }
}
