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
        public int UserID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int RoleID { get; set; }
        public bool? IsActive { get; set; }
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
