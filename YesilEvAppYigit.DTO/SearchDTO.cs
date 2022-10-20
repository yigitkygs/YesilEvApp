using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvAppYigit.DTO
{
    public class SearchDTO
    {
        [Browsable(false)]
        public int SearchID { get; set; }

        [DisplayName("Aranan Kelime")]
        public string SearchKeyword { get; set; }

        [DisplayName("Arama Tarihi")]
        public DateTime? SearchDate { get; set; } = DateTime.Now;

        [Browsable(false)]
        public int UserID { get; set; }

        [Browsable(false)]
        public bool IsDeleted { get; set; }
    }
}
