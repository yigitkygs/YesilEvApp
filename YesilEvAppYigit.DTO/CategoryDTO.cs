using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvAppYigit.DTO
{
    public class CategoryDTO
    {
        [DisplayName("Kategori ID")]

        public int CategoryID { get; set; }

        [Required]
        [DisplayName("Kategori Adı")]

        public string CategoryName { get; set; }
        [Required]
        [DisplayName("Üst Kategori ID")]

        public int UpperCategoryID { get; set; }
        [DisplayName("Aktif mi")]

        public bool? IsActive { get; set; }
        [DisplayName("Ekleme Tarihi")]

        public DateTime? CreateDate { get; set; }

        public override string ToString()
        {
            return CategoryName;
        }
    }
}
