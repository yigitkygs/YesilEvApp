using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YesilEvAppYigit.DTO
{
    public class BlacklistDTO
    {
        [Browsable(false)]
        public int BlacklistID { get; set; }

        [Required]
        [DisplayName("Kullan?c? No")]
        public int UserID { get; set; }

        [DisplayName("Eklenme Tarihi")]
        public DateTime? CreateDate { get; set; }

        [DisplayName("Aktif Mi?")]
        public bool? IsActive { get; set; }
        [Browsable(false)]
        public UserDTO User { get; set; }
        [Browsable(false)]
        public List<BlacklistAllergenDTO> BlacklistAllergens { get; set; }
    }
}
