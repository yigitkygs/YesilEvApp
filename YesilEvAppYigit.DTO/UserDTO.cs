using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvAppYigit.DTO
{
    public class UserDTO
    {
        [DisplayName("Kullanıcı ID")]
        public int UserID { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Şifre Hash'i")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Rol No")]
        public int RoleID { get; set; }

        [DisplayName("Aktif Mi?")]
        public bool? IsActive { get; set; }

        [DisplayName("Ekleme Tarihi")]
        public DateTime? CreateDate { get; set; }

        [Browsable(false)]
        public List<BlacklistDTO> Blacklists { get; set; }

        [Browsable(false)]
        public List<FavoriteDTO> Favorites { get; set; }

        [Browsable(false)]
        public List<SearchDTO> Searches { get; set; }

        public override string ToString()
        {
            return Username;
        }
    }
}
