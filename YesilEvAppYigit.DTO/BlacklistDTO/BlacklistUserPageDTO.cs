using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvAppYigit.DTO
{
    public class BlacklistUserPageDTO
    {
        [Browsable(false)]
        public int BlacklistID { get; set; }
        [Browsable(false)]
        public int BlacklistAllergenID { get; set; }
        [Browsable(false)]
        public int AllergenID { get; set; }
        [DisplayName("Alerjen Adı")]
        public string AllergenName { get; set; }
        [Browsable(false)]
        public int UserID { get; set; }

        [DisplayName("Ekleme Tarihi")]
        public DateTime? CreateDate { get; set; }
    }
}
