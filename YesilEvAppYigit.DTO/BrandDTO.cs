using System;
using System.Collections.Generic;
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
        public int UreticiID { get; set; }

        public ManufacturerDTO Manufacturer { get; set; }

        public override string ToString()
        {
            return BrandName;
        }
    }
}
