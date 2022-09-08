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
        public int CategoryID { get; set; }

        [Required]

        public string CategoryName { get; set; }
        [Required]

        public int UpperCategoryID { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }

        public override string ToString()
        {
            return CategoryName;
        }
    }
}
