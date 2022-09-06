using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace YesilEvAppYigit.DTO
{
    public class FavoriUrunDTO
    {
        public int ID { get; set; }

        [Required]
        public int FavoriID { get; set; }

        [Required]
        public int UrunID { get; set; }

        public DateTime? DateAdded { get; set; }

        public bool? IsActive { get; set; }

        public FavoriteDTO Favorite { get; set; }

        public ProductDTO Product { get; set; }
    }
}
