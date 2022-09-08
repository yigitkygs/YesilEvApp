using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvAppYigit.Core;

namespace YesilEvAppYigit.DTO
{
    public class ProductDTO
    {
        public int ProductID { get; set; }

        [Required]
        public string BarcodeNo { get; set; }

        [Required]
        public int BrandID { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int KategoriID { get; set; }
        public string ProductIngredientsText { get; set; }

        [Browsable(false)]
        public byte[] ProductIngredientsImg { get; set; }

        [Browsable(false)]
        public byte[] FrontImg { get; set; }

        [Browsable(false)]
        public byte[] BackImg { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public int AddedBy { get; set; }

        public bool? IsApproved { get; set; }

        [Browsable(false)]
        public List<FavoriteProductDTO> FavoriteProducts { get; set; }

        [Browsable(false)]
        public List<ProductAllergenDTO> ProductAllergens { get; set; }

        public override string ToString()
        {
            return ProductName;
        }
    }
}
