using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace YesilEvAppYigit.DTO
{
    public class FavoriteProductDTO
    {
        public int FavoriteProductID { get; set; }

        [Required]
        public int FavoriteID { get; set; }

        [Required]
        public int ProductID { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? IsActive { get; set; }

        public FavoriteDTO Favorite { get; set; }

        public ProductDTO Product { get; set; }
    }
}
