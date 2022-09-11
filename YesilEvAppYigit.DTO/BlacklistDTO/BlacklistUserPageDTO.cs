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
        public string AllergenName { get; set; }
        [Browsable(false)]
        public int UserID { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
