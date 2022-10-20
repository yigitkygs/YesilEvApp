using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YesilEvAppYigit.Core;

namespace YesilEvAppYigit.DTO
{
    public class BlacklistAllergenDTO
    {
        [DisplayName("ID")]
        public int BlacklistAllergenID { get; set; }
        [DisplayName("Kara liste No")]
        [Required]
        public int BlacklistID { get; set; }
        [DisplayName("Alerjen ID")]
        [Required]
        public int AllergenID { get; set; }
        [DisplayName("Kullan?c? Id")]

        public int UserID { get; set; }
        [DisplayName("Ekleme Tarihi")]

        public DateTime? CreateDate { get; set; }
        [DisplayName("Aktif mi")]

        public bool? IsActive { get; set; }
        [Browsable(false)]

        public Allergen Allergen { get; set; }
        [Browsable(false)]

        public Blacklist Blacklist { get; set; }
    }
}
