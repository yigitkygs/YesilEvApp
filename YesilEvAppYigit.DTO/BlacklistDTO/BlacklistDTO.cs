using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YesilEvAppYigit.DTO
{
    public class BlacklistDTO
    {
        public int BlacklistID { get; set; }
        [Required]
        public int UserID { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? IsActive { get; set; }
        public UserDTO User { get; set; }
        public List<BlacklistAllergenDTO> BlacklistAllergens { get; set; }
    }
}
