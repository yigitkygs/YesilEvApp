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
    public class ProductUserPageDTO
    {
        [Browsable(false)]
        public int ProductID { get; set; }

        [DisplayName("Barkod No")]
        public string BarcodeNo { get; set; }

        [DisplayName("Ürün Adı")]
        public string ProductName { get; set; }

        [DisplayName("Eklenme Tarihi")]
        public DateTime? CreateDate { get; set; }

        public override string ToString()
        {
            return ProductName;
        }
    }
}
