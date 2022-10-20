using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YesilEvAppYigit.DTO
{
    public class FavoriteDTO
    {
        [DisplayName("Favori ID")]
        public int FavoriteID { get; set; }

        [DisplayName("Favori Ad?")]
        public string FavoriteName { get; set; }

        [DisplayName("Kullan?c? ID")]
        [Required]
        public int UserID { get; set; }

        [DisplayName("Ekleme Tarihi")]
        public DateTime? CreateDate { get; set; }

        [DisplayName("Aktif mi")]
        public bool? IsActive { get; set; }

        [Browsable(false)]
        public UserDTO User { get; set; }

        [Browsable(false)]
        public List<FavoriteProductDTO> FavoriteProduct { get; set; }

        public override string ToString()
        {
            return FavoriteName;
        }
    }
}
