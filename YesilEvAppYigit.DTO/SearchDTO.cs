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
        public string SearchKeyword { get; set; }
        public DateTime? SearchDate { get; set; } = DateTime.Now;

        [Browsable(false)]
        public int UserID { get; set; }

        [Browsable(false)]
        public bool IsDeleted { get; set; }
    }
}
