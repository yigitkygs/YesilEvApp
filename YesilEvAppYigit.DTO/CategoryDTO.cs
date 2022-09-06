using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvAppYigit.DTO
{
    public class CategoryDTO
    {
        public int KategoriID { get; set; }

        [Required]

        public string KategoriAdi { get; set; }
        [Required]

        public int UstKategoriID { get; set; }

        public override string ToString()
        {
            return KategoriAdi;
        }
    }
}
