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
        [DisplayName("Ürün No")]
        public int ProductID { get; set; }

        [DisplayName("Barkod No")]
        [Required]
        public string BarcodeNo { get; set; }

        [DisplayName("Marka No")]
        [Required]
        public int BrandID { get; set; }

        [DisplayName("Ürün Adı")]
        [Required]
        public string ProductName { get; set; }

        [DisplayName("Kategori No")]
        [Required]
        public int CategoryID { get; set; }

        [Browsable(false)]
        public byte[] ProductIngredientsImg { get; set; }

        [Browsable(false)]
        public byte[] FrontImg { get; set; }

        [Browsable(false)]
        public byte[] BackImg { get; set; }
        [DisplayName("Ürün Aktif Mi?")]

        public bool? IsActive { get; set; }

        [DisplayName("Kullanıcı İzin Verdi Mi?")]

        public bool? DoesUserConsent { get; set; }
        [DisplayName("Ekleme Tarihi")]

        public DateTime? CreateDate { get; set; }

        [DisplayName("Ekleme Tarihi")]

        public int AddedBy { get; set; }

        [DisplayName("Onaylandı Mı?")]

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
