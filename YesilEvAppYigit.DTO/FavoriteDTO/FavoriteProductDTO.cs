using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace YesilEvAppYigit.DTO
{
    public class FavoriteProductDTO
    {
        [Browsable(false)]
        public int FavoriteProductID { get; set; }

        [Required]
        [Browsable(false)]
        public int FavoriteID { get; set; }

        [Required]
        [Browsable(false)]
        public int ProductID { get; set; }

        [DisplayName("Ürün Ad?")]
        public string ProductName { get; set; }

        [DisplayName("Eklenme Tarihi")]
        public DateTime? CreateDate { get; set; }

        [Browsable(false)]
        public bool? IsActive { get; set; }

        [Browsable(false)]
        public FavoriteDTO Favorite { get; set; }

        [Browsable(false)]
        public ProductDTO Product { get; set; }


    }
}
