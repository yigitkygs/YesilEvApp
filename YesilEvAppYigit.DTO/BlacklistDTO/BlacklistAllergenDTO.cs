using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YesilEvAppYigit.Core;

namespace YesilEvAppYigit.DTO
{
    public class BlacklistAllergenDTO
    {
        public int ID { get; set; }
        [Required]
        public int BlacklistID { get; set; }
        [Required]
        public int AllergenID { get; set; }
        public int UserID { get; set; }

        public DateTime? DateAdded { get; set; }

        public bool? IsActive { get; set; }

        public Allergen Allergen { get; set; }

        public Blacklist Blacklist { get; set; }
    }
}
