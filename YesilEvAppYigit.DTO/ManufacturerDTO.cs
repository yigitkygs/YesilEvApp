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
        public int ManufacturerID { get; set; }

        [Required]
        public string ManufacturerName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }

        [Browsable(false)]
        public List<BrandDTO> Brand { get; set; }
    }
}
