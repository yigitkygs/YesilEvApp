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
        public int BrandID { get; set; }
        [Required]
        public string BrandName { get; set; }
        [Required]
        public int ManufacturerID { get; set; }

        [Browsable(false)]
        public ManufacturerDTO Manufacturer { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }

        public override string ToString()
        {
            return BrandName;
        }
    }
}
