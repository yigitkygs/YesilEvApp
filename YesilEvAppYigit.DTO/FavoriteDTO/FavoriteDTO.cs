using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YesilEvAppYigit.DTO
{
    public class FavoriteDTO
    {
        public int ListID { get; set; }

        public string ListName { get; set; }
        [Required]
        public int UserID { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? IsActive { get; set; }

        public UserDTO User { get; set; }

        public List<FavoriUrunDTO> FavoriUruns { get; set; }

        public override string ToString()
        {
            return ListName;
        }
    }
}
