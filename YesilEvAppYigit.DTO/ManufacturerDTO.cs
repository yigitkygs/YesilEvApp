using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvAppYigit.DTO
{
    public class ManufacturerDTO
    {
        public int UreticiID { get; set; }

        [Required]
        public string UreticiAdi { get; set; }
        public List<BrandDTO> Brand { get; set; }
    }
}
