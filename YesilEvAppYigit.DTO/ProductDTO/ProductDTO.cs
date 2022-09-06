using System;
using System.Collections.Generic;
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
        public int UrunID { get; set; }
        [Required]
        public string BarkodNo { get; set; }
        [Required]
        public int BrandID { get; set; }
        [Required]
        public string UrunAdi { get; set; }
        [Required]
        public int KategoriID { get; set; }
        public string UrunIcerigiText { get; set; }
        public byte[] UrunIcerigiImg { get; set; }
        public byte[] OnYuzu { get; set; }
        public byte[] ArkaYuzu { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateAdded { get; set; }

        public int AddedBy { get; set; }

        public bool? IsApproved { get; set; }
        public List<FavoriUrunDTO> FavoriUruns { get; set; }
        public List<UrunAllergenDTO> UrunAllergens { get; set; }

        public override string ToString()
        {
            return UrunAdi;
        }
    }
}
